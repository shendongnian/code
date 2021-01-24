        public static bool RangeContainsDate(DateTime queriedDateTime)
            {
                var queriedDateRange = new DateRange { Date = queriedDateTime };
                List<DateRange> dates = GetDateRange();
                return dates.Where(d => d.CompareTo(queriedDateRange) == 0).Any();
            }
    
            /**List of Dates Here - Starts**/
            public static List<DateRange> GetDateRange()
            {
                List<DateRange> lstDate = new List<DateRange>();
    
                DateRange aDateRange1 = new DateRange();
                aDateRange1.Date = Convert.ToDateTime("10-Aug-2018");
                lstDate.Add(aDateRange1);
    
                DateRange aDateRange2 = new DateRange();
                aDateRange2.Date = Convert.ToDateTime("11-Aug-2018");
                lstDate.Add(aDateRange2);
    
                DateRange aDateRange3 = new DateRange();
                aDateRange3.Date = Convert.ToDateTime("12-Aug-2018");
                lstDate.Add(aDateRange3);
    
                DateRange aDateRange4 = new DateRange();
                aDateRange4.Date = Convert.ToDateTime("13-Aug-2018");
                lstDate.Add(aDateRange4);
    
                return lstDate;
            }
        }
    }
    
    public class DateRange : IComparable<DateRange>
    {
        public DateTime Date { set; get; }
    
        public int CompareTo(DateRange other)
        {
            if (ReferenceEquals(other, null))
            {
                return -1;
            }
            return DateTime.Compare(Date, other.Date);
        }
    
    }
