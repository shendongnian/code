    using System;
    
    namespace DataTime {
        class Program {
            static int GetQuarter (DateTime dt) {
                int Month = dt.Month;   // from 1 to 12
                return Month / 4 + 1;
            }
            static DateTime GetQuarterFirstDay (DateTime dt) {
                int monthsOfTheFirstDayOfQuarter = (GetQuarter (dt) - 1) * 4;
                return new DateTime (dt.Year, dt.Month, 1);
            }
            static void Main (string[] args) {
                DateTime dt1 = new DateTime (2009, 6, 9),
                         dt2 = new DateTime (2009, 7, 9),
                         dt3 = new DateTime (2009, 8, 9),
                         dt4 = new DateTime (2009, 8, 9);
    
                Console.WriteLine ("dt1={0}", dt1.AddMonths (1));
                Console.WriteLine ("dt2={0}", dt2.AddMonths (1));
                Console.WriteLine ("dt3={0}", dt3.AddMonths (1));
    
                DateTime startDate = DateTime.Now,
                         endDate1 = startDate.AddMonths(24).AddDays(1),
                         endDate2 = startDate.AddMonths(24).AddDays(-1),
                         endDate3 = startDate.AddMonths(30);
                Console.WriteLine ("Now we have={0}", startDate);
                Console.WriteLine ("endDate1={0}", endDate1);
                Console.WriteLine ("endDate2={0}", endDate2);
                Console.WriteLine ("endDate3={0}", endDate3);
    
            Console.WriteLine ("GetQuarterFirstDay(startDate)={0}", GetQuarterFirstDay (startDate));
            Console.WriteLine ("GetQuarterFirstDay(endDate1)={0}", GetQuarterFirstDay (endDate1));
            Console.WriteLine ("GetQuarterFirstDay(endDate2)={0}", GetQuarterFirstDay (endDate2));
            Console.WriteLine ("GetQuarterFirstDay(endDate3)={0}", GetQuarterFirstDay (endDate3));
                if (DateTime.Compare (GetQuarterFirstDay (endDate2), GetQuarterFirstDay (startDate).AddMonths (24)) > 0)
                    Console.WriteLine ("> 2 Yeas");
                else
                    Console.WriteLine ("<= 2 Yeas");
                if (DateTime.Compare (GetQuarterFirstDay (endDate3), GetQuarterFirstDay (startDate).AddMonths (24)) > 0)
                    Console.WriteLine ("> 2 Yeas");
                else
                    Console.WriteLine ("<= 2 Yeas");
            }
        }
    }
