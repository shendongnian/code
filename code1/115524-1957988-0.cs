    using System;
    
    public class Date
    {
        int year, month, day;
    
        public Date(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }
    
        public static Date operator ++(Date d)
        { 
            return d.Next();
        }
        
        private Date Next()
        {
            // Just a toy implementation, obviously
            return new Date(day + 1, month, year);
        }
        
        static void Main()
        {
            Date x = new Date(1, 2, 3);
            x++;
            Console.WriteLine(x.day); // Prints 2
        }
    }
