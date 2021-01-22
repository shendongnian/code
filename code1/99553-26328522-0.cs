    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime start = new DateTime(2014, 1, 1);
                DateTime stop = new DateTime(2014, 12, 31);
    
                int totalWorkingDays = GetNumberOfWorkingDays(start, stop);
    
                Console.WriteLine("There are {0} working days.", totalWorkingDays);
            }
    
            private static int GetNumberOfWorkingDays(DateTime start, DateTime stop)
            {
                TimeSpan interval = stop - start;
    
                int totalWeek = interval.Days / 7;
                int totalWorkingDays = 5 * totalWeek;
    
                int remainingDays = interval.Days % 7;
    
    
                for (int i = 0; i < remainingDays; i++)
                {
                    DayOfWeek test = (DayOfWeek)(((int)start.DayOfWeek + i) % 7);
                    if (test >= DayOfWeek.Monday && test <= DayOfWeek.Friday)
                        totalWorkingDays++;
                }
    
                return totalWorkingDays;
            }
        }
    }
