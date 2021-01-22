    using System;
    using System.Text;
    
    namespace fooLib
    {
        /// <summary>
        /// Timespan where you can define the number of hours a day can last (+ days of week).
        /// Optimal for calculating bussinesshours.
        /// </summary>
        public class DynamicTimeSpan
        {
            private int _hoursPerDay = 8;
            private int _daysPerWeek = 5;
            private int _totalMinutes = 0;
    
            public int HoursPerDay
            {
                get { return _hoursPerDay; }
                set { _hoursPerDay = value; }
            }
    
            public int DaysPerWeek
            {
                get { return _daysPerWeek; }
                set { _daysPerWeek = value; }
            }
    
            public int Weeks
            {
                get
                {
                    return  (int)(((_totalMinutes / 60) / this.HoursPerDay) / this.DaysPerWeek);
                }
            }
    
            public int Days
            {
                get
                {
                    return (int)((decimal)TotalDays - (decimal)(Weeks * this.DaysPerWeek));
                }
            }
    
            public int Hours
            {
                get
                {
                    return (int)((decimal)TotalHours - (decimal)(Weeks * this.DaysPerWeek * this.HoursPerDay) - (decimal)(Days * this.HoursPerDay));
                }
            }
    
            public int Minutes
            {
                get
                {
                    return _totalMinutes - (Weeks * this.DaysPerWeek * this.HoursPerDay * 60) - (Days * this.HoursPerDay * 60) - (Hours * 60);
                }
            }
    
            public decimal TotalDays
            {
                get { return (decimal)_totalMinutes / (decimal)60 / (decimal)this.HoursPerDay; }
            }
    
            public decimal TotalHours
            {
                get { return (decimal)_totalMinutes / (decimal)60; }
            }
    
            public int TotalMinutes
            {
                get { return _totalMinutes; }
            }
    
            public static DynamicTimeSpan operator +(DynamicTimeSpan ts1, DynamicTimeSpan ts2)
            {
                return new DynamicTimeSpan(ts1._totalMinutes + ts2._totalMinutes);
            }
    
            public static DynamicTimeSpan operator -(DynamicTimeSpan ts1, DynamicTimeSpan ts2)
            {
                return new DynamicTimeSpan(ts1._totalMinutes - ts2._totalMinutes);
            }
    
            public DynamicTimeSpan()
            {
    
            }
    
            public DynamicTimeSpan(int totalMinutes)
            {
                _totalMinutes = totalMinutes;
            }
    
            public DynamicTimeSpan(int weeks, int days, int hours, int minutes)
            {
                _totalMinutes = (weeks * this.DaysPerWeek * this.HoursPerDay * 60) + (days * this.HoursPerDay * 60) + (hours * 60) + minutes;
            }
    
            /// <summary>
            /// "1 week 2 days 4 hours 30 minutes"
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                string str = "";
    
                if (this.Weeks == 1)
                {
                    str += this.Weeks + " week ";
                }
                else if (this.Weeks > 1)
                {
                    str += this.Weeks + " weeks ";
                }
    
                if (this.Days == 1)
                {
                    str += this.Days + " day ";
                }
                else if (this.Days > 1)
                {
                    str += this.Days + " days ";
                }
    
                if (this.Hours == 1)
                {
                    str += this.Hours + " hour ";
                }
                else if (this.Hours > 1)
                {
                    str += this.Hours + " hours ";
                }
    
                // only write minutes when the duration is lower than one day
                if (this.Weeks == 0 && this.Days == 0 && this.Minutes > 0)
                {
                    str += this.Minutes + " minutes";
                }
    
                return str;
            }
        }
    }
