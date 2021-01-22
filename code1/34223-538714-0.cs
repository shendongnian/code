    using System;
    using System.Net;
    
    public class Test
    {
        static void Main(string[] args)
        {
            Check(new DateTime(2005, 1, 12));
            Check(new DateTime(2009, 2, 28));
            Check(new DateTime(2009, 12, 31));
            Check(new DateTime(2000, 1, 29));
            Check(new DateTime(2100, 1, 29));
        }
        
        static void Check(DateTime date)
        {
            DateTime? next = OneMonthAfter(date);
            Console.WriteLine("{0} {1}", date,
                              next == null ? (object) "Error" : next);
        }
        
        static DateTime? OneMonthAfter(DateTime date)
        {
            DateTime ret = date.AddMonths(1);
            if (ret.Day != date.Day)
            {
                // Or throw an exception
                return null;
            }
            return ret;
        }
    }
