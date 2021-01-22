    using System;
    
    namespace Question2355777
    {
        class Program
        {    
            private static bool IsInOvernightWindow(
                DateTime dateTimeUnderTest, 
                TimeSpan morningEnd, 
                TimeSpan eveningStart)
            {
                TimeSpan timeOfDay = dateTimeUnderTest.TimeOfDay;
                return timeOfDay <= morningEnd || timeOfDay >= eveningStart;
            }
            static void Main(string[] args)
            {
                TimeSpan eveningStart = TimeSpan.FromHours(20);
                TimeSpan morningEnd = TimeSpan.FromHours(7);
    
                Console.WriteLine("{0} {1}", 
                    DateTime.Today.AddHours(3),
                    IsInOvernightWindow(
                        DateTime.Today.AddHours(3), 
                        morningEnd, 
                        eveningStart));
    
                Console.WriteLine("{0} {1}", 
                    DateTime.Today.AddHours(12),
                    IsInOvernightWindow(
                        DateTime.Today.AddHours(12), 
                        morningEnd, 
                        eveningStart));
    
                Console.WriteLine("{0} {1}", 
                    DateTime.Today.AddHours(21),
                    IsInOvernightWindow(
                        DateTime.Today.AddHours(21), 
                        morningEnd, 
                        eveningStart));
    
                Console.ReadLine();
            }
        }
    }
