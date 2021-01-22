    using System;
    
    public static class Test
    {
        public static void Main()
        {
            string[] dates = { "Jan 12, 2005", "Feb 28, 2009", "Dec 31, 2009", "Jan 29, 2000", "Jan 29, 2100" };
            foreach (string date in dates)
            {
                DateTime t1 = DateTime.Parse(date);
                DateTime t2 = t1.AddMonths(1);
                if (t1.Day != t2.Day)
                    Console.WriteLine("Error: no " + t2.ToString("MMM") + " " + t1.Day + ", " + t2.Year);
                else
                    Console.WriteLine(t2.ToString("MMM dd, yyyy"));
            }
            Console.ReadLine();   
        }
    }
