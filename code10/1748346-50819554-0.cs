    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace stack_days
    {
        class Program
        {
            static void Main(string[] args)
            {
                //(1)
                string helloText = "Good " + getHoursText() + " ! ";
                //(2)
                string todayDate = "Today's date is " + DateTime.Now.ToShortDateString() + " ( " + DateTime.Now.DayOfWeek + " ) ";
                //(3)
                string specialDay = getSpecialDayIfDay();
    
                string fullText = helloText + todayDate + specialDay;
    
                Console.WriteLine(fullText);
                Console.ReadKey();
                
            }
    
            private static string getSpecialDayIfDay()
            {
                string info = "You have to concentrate on ";
                if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                {
                    return info + "Wednesday and Thursday";
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                {
                    return info + "Weekend";
                }
                else
                {
                    return null;
                }
            }
    
            private static string getHoursText()
            {
                string partOfDay = "";
                int hours = DateTime.Now.Hour;
                if (hours > 18)
                {
                    partOfDay = "evening";
                }
                else if (hours > 12)
                {
                    partOfDay = "afternoon";
                }
                else if (hours > 6)
                {
                    partOfDay = "morning";
                }
                else
                {
                    partOfDay = "evening";
                }
    
                return partOfDay;
            }
        }
    }
