    public class Entry
        {
            private int _reference; 
            private string _donation;
            private DateTime _date;
            private double _amount;
    
            public Entry(int aReference, string aDonation, DateTime aDate, double aAmount)
                {
                    _reference = aReference;
                    _donation = aDonation;
                    _date = aDate;
                    _amount = aAmount;
                }
    
            public double Amount
            {
                get { return _amount; }
                set { _amount = value; }
            }
    
            public DateTime Date
            {
                get { return _date; }
                set { _date = value; }
            }
    
            public string Donation
            {
                get { return _donation; }
                set { _donation = value; }
            }
    
            public int Reference 
            {
                get { return _reference; }
                set { _reference = value; }
            }
    }
