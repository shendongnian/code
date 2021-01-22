    /// <summary>
    /// Time structure
    /// </summary>
    public struct Time : IComparable
    {
        private int minuteOfDay;
        public static Time Midnight = "0:00";
        private static int MIN_OF_DAY = 60 * 24;
        public Time(int minuteOfDay)
        {
            if (minuteOfDay >= (60 * 24) || minuteOfDay < 0)
                throw new ArgumentException("Skal ligge i intervallet 0 - 1439", "minuteOfDay");
            this.minuteOfDay = minuteOfDay;
        }
        public Time(int hour, int minutes)
        {
            if (hour < 0 || hour > 23)
                throw new ArgumentException("Must be in the range 0-23", "hour");
            if (minutes < 0 || minutes > 59)
                throw new ArgumentException("Must be in the range 0-59", "minutes");
            minuteOfDay = (hour * 60) + minutes;
        }
        #region Operators
        public static implicit operator Time(string s)
        {
            var parts = s.Split(':');
            if (parts.Length != 2)
                throw new ArgumentException("Time must be specified on the form tt:mm");
            return new Time(int.Parse(parts[0]), int.Parse(parts[1]));
        }
        public static bool operator >(Time t1, Time t2)
        {
            return t1.MinuteOfDay > t2.MinuteOfDay;
        }
        public static bool operator <(Time t1, Time t2)
        {
            return t1.MinuteOfDay < t2.MinuteOfDay;
        }
        public static bool operator >=(Time t1, Time t2)
        {
            return t1.MinuteOfDay >= t2.MinuteOfDay;
        }
        public static bool operator <=(Time t1, Time t2)
        {
            return t1.MinuteOfDay <= t2.MinuteOfDay;
        }
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.GetHashCode() == t2.GetHashCode();
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return t1.GetHashCode() != t2.GetHashCode();
        }
        /// Time
        /// Minutes that remain to
        /// Time conferred minutes
        public static Time operator +(Time t, int min)
        {
            if (t.minuteOfDay + min < (24 * 60))
            {
                t.minuteOfDay += min;
                return t;
            }
            else
            {
                t.minuteOfDay = (t.minuteOfDay + min) % MIN_OF_DAY;
                return t;
            }
        }
        public static Time operator -(Time t, int min)
        {
            if (t.minuteOfDay - min > -1)
            {
                t.minuteOfDay -= min;
                return t;
            }
            else
            {
                t.minuteOfDay = MIN_OF_DAY + (t.minuteOfDay - min);
                return t;
            }
        }
        public static TimeSpan operator -(Time t1, Time t2)
        {
            return TimeSpan.FromMinutes(Time.Span(t2, t1));
        }
        #endregion
        public int Hour
        {
            get
            {
                return (int)(minuteOfDay / 60);
            }
        }
        public int Minutes
        {
            get
            {
                return minuteOfDay % 60;
            }
        }
        public int MinuteOfDay
        {
            get { return minuteOfDay; }
        }
        public Time AddHours(int hours)
        {
            return this + (hours * 60);
        }
        public int CompareTo(Time other)
        {
            return this.minuteOfDay.CompareTo(other.minuteOfDay);
        }
        #region Overrides
        public override int GetHashCode()
        {
            return minuteOfDay.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}:{1:00}", Hour, Minutes);
        }
        #endregion
        /// 
        /// Safe enumerering - whatever interval applied max days 
        /// 
        /// Start time
        /// Spring in minutes
        /// 
        public static IEnumerable Range(Time start, int step)
        {
            return Range(start, start, step);
        }
        /// 
        /// Safe enumerering - whatever interval applied max days
        /// 
        public static IEnumerable Range(Time start, Time stop, int step)
        {
            int offset = start.MinuteOfDay;
            for (var i = 0; i < Time.Span(start, stop); i += step)
            {
                yield return Time.Midnight + (i + offset);
            }
        }
        /// 
        /// Calculates the number of minutes between t1 and t2
        /// 
        public static int Span(Time t1, Time t2)
        {
            if (t1 < t2) // same day
                return t2.MinuteOfDay - t1.MinuteOfDay;
            else // over midnight
                return MIN_OF_DAY - t1.MinuteOfDay + t2.MinuteOfDay;
        }
    }
