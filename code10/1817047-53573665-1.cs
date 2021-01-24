    public class Entry2:Entry
        {
            private DateTime _date2;
    
            public Entry2(string aReference, string aDonation, DateTime aDate, double aAmount, DateTime aDate2)
            :base(aReference, aDonation, aDate, aAmount)
            {
                _date2 = aDate2;
            }
    
            public DateTime Date2
            {
                get { return _date2; }
                set { _date2 = value; }
            }
        }
