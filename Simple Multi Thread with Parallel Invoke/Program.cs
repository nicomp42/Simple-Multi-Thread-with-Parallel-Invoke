/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Multi_Thread_with_Parallel_Invoke
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 2_000_000_000;
            Console.WriteLine("Parallel: count to " + limit + " three times");
            DemoParallel(limit);
            Console.WriteLine("Serial: count to " + limit + " three times");
            DemoSerial(limit);
        }
        /// <summary>
        /// Serial equivalent of the DemoParallel method, below. 
        /// </summary>
        /// <param name="limit"></param>
        private static void DemoSerial(int limit)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Begin first task...");
            for (int i = 0; i < limit; i++)
            {
            }
            Console.WriteLine("Begin second task...");
            for (int i = 0; i < limit; i++)
            {
            }
            Console.WriteLine("Begin third task...");
            for (int i = 0; i < limit; i++)
            {
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedTicks / 10_000 + " milliseconds.");

        }
        /// <summary>
        /// Demonstrate the Parallel.Invoke method of .Net
        /// </summary>
        /// <param name="limit"></param>
        private static void DemoParallel(int limit)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(
                () =>
                {
                    Console.WriteLine("Begin first task...");
                    for (int i = 0; i < limit; i++)
                    {
                    }
                },  // close first Action

                () =>
                {
                    Console.WriteLine("Begin second task...");
                    for (int i = 0; i < limit; i++)
                    {
                    }
                }, //close second Action

                () =>
                {
                    Console.WriteLine("Begin third task...");
                    for (int i = 0; i < limit; i++)
                    {
                    }
                } //close third Action
            ); //close parallel.invoke
            stopwatch.Stop();
            Console.WriteLine( stopwatch.ElapsedTicks / 10_000 + " milliseconds.");

        }
    }
}
