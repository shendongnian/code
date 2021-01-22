    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace Benfords
    {
        class Program
        {
            static int FirstDigit1(int value)
            {
                return Convert.ToInt32(value.ToString().Substring(0, 1));
            }
    
            static int FirstDigit2(int value)
            {
                while (value >= 10) value /= 10;
                return value;
            }
    
    
            static int FirstDigit3(int value)
            {
                return (int)(value.ToString()[0]) - 48;
            }
    
            static int FirstDigit4(int value)
            {
                return (int)(value / Math.Pow(10, (int)Math.Floor(Math.Log10(value))));
            }
    
            static int FirstDigit5(int value)
            {
                if (value < 10) return value;
                if (value < 100) return value / 10;
                if (value < 1000) return value / 100;
                if (value < 10000) return value / 1000;
                if (value < 100000) return value / 10000;
                if (value < 1000000) return value / 100000;
                if (value < 10000000) return value / 1000000;
                if (value < 100000000) return value / 10000000;
                if (value < 1000000000) return value / 100000000;
                return value / 1000000000;
            }
    
            static int FirstDigit6(int value)
            {
                if (value >= 100000000) value /= 100000000;
                if (value >= 10000) value /= 10000;
                if (value >= 100) value /= 100;
                if (value >= 10) value /= 10;
                return value;
            }
    
            const int mcTests = 1000000;
    
            static void Main(string[] args)
            {
                Stopwatch lswWatch = new Stopwatch();
                Random lrRandom = new Random();
    
                int liCounter;
    
                lswWatch.Start();
                for (liCounter = 0; liCounter < mcTests; liCounter++)
                    FirstDigit1(lrRandom.Next());
                lswWatch.Stop();
                Console.WriteLine("Test {0} = {1} ticks", 1, lswWatch.ElapsedTicks);
    
                lswWatch.Reset();
                lswWatch.Start();
                for (liCounter = 0; liCounter < mcTests; liCounter++)
                    FirstDigit2(lrRandom.Next());
                lswWatch.Stop();
                Console.WriteLine("Test {0} = {1} ticks", 2, lswWatch.ElapsedTicks);
    
                lswWatch.Reset();
                lswWatch.Start();
                for (liCounter = 0; liCounter < mcTests; liCounter++)
                    FirstDigit3(lrRandom.Next());
                lswWatch.Stop();
                Console.WriteLine("Test {0} = {1} ticks", 3, lswWatch.ElapsedTicks);
    
                lswWatch.Reset();
                lswWatch.Start();
                for (liCounter = 0; liCounter < mcTests; liCounter++)
                    FirstDigit4(lrRandom.Next());
                lswWatch.Stop();
                Console.WriteLine("Test {0} = {1} ticks", 4, lswWatch.ElapsedTicks);
    
                lswWatch.Reset();
                lswWatch.Start();
                for (liCounter = 0; liCounter < mcTests; liCounter++)
                    FirstDigit5(lrRandom.Next());
                lswWatch.Stop();
                Console.WriteLine("Test {0} = {1} ticks", 5, lswWatch.ElapsedTicks);
    
                lswWatch.Reset();
                lswWatch.Start();
                for (liCounter = 0; liCounter < mcTests; liCounter++)
                    FirstDigit6(lrRandom.Next());
                lswWatch.Stop();
                Console.WriteLine("Test {0} = {1} ticks", 6, lswWatch.ElapsedTicks);
    
                Console.ReadLine();
            }
        }
    }
