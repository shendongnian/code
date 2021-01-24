        using System;
    
        namespace ConsoleApp4
        {
            internal class Program
            {
                private static void Main(string[] args)
                {
                    AttemptController.Init(3, 2);
                    Console.WriteLine("Maximum:   {0}", AttemptController.MaxAttempts);
                    Console.WriteLine("Warning:   {0}", AttemptController.WarningAttempts);
                    Console.WriteLine("Threshold: {0}", AttemptController.Threshold);
    
                    AttemptController.Init(7, 5);
                    Console.WriteLine("Maximum:   {0}", AttemptController.MaxAttempts);
                    Console.WriteLine("Warning:   {0}", AttemptController.WarningAttempts);
                    Console.WriteLine("Threshold: {0}", AttemptController.Threshold);
                    Console.ReadLine();
            }
        }
    
            public static class AttemptController
            {
                internal static int MaxAttempts;
                internal static int WarningAttempts;
                internal static int Threshold;
    
    
                
                public static void Init(int a, int b)
                {
                    MaxAttempts = MaxAttempts + a;
                    WarningAttempts = WarningAttempts + b;
                    Threshold = MaxAttempts - WarningAttempts;
                }
            }
        }
