    class Program
    {
        static void Main()
        {
            var dtInfo = new System.Globalization.DateTimeFormatInfo();            
            Console.WriteLine("Old array of abbreviated dates:");
            var dt = DateTime.Today;
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(dt.AddDays(i).ToString("ddd", dtInfo));
            }
    
            // change the short weekday names array
            var newWeekDays = new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa" };
            dtInfo.AbbreviatedDayNames = newWeekDays;
            
            Console.WriteLine("New array of abbreviated dates:");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(dt.AddDays(i).ToString("ddd", dtInfo));
            }
    
            Console.ReadLine();
        }
    }
