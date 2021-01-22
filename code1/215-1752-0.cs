    public class RelativeTimeRange : IComparable
    {
        public TimeSpan UpperBound { get; set; }
        public delegate string RelativeTimeTextDelegate(TimeSpan timeDelta);
        public RelativeTimeTextDelegate RelativeTimeMessage { get; set; }
        public int CompareTo(object obj)
        {
            if (!(obj is RelativeTimeRange))
            {
                return 1;
            }
            // note that this sorts in reverse order to the way you'd expect, 
            // this saves having to reverse a list later
            return (obj as RelativeTimeRange).UpperBound.CompareTo(UpperBound);
        }
    }
    public class PrintRelativeTime
    {
        private static List<RelativeTimeRange> timeRanges;
        static PrintRelativeTime()
        {
            timeRanges = new List<RelativeTimeRange>();
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromSeconds(1),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "one second ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromSeconds(60),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return timeDelta.Seconds + " seconds ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromMinutes(2),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "one minute ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromMinutes(60),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return timeDelta.Minutes + " minutes ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromHours(2),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "one hour ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromHours(24),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return timeDelta.Hours + " hours ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.FromDays(2),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "yesterday"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = DateTime.Now.Subtract(DateTime.Now.AddMonths(-1)),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return timeDelta.Days + " days ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = DateTime.Now.Subtract(DateTime.Now.AddMonths(-2)),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "one month ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = DateTime.Now.Subtract(DateTime.Now.AddYears(-1)),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return Convert.ToInt32(Math.Floor((double)timeDelta.Days / 30)) + " months ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = DateTime.Now.Subtract(DateTime.Now.AddYears(-2)),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "one year ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = DateTime.Now.Subtract(DateTime.Now.AddMonths(-1)),
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return "one month ago"; }
            });
            timeRanges.Add(new RelativeTimeRange
            {
                UpperBound = TimeSpan.MaxValue,
                RelativeTimeMessage = delegate(TimeSpan timeDelta) 
                    { return Convert.ToInt32(Math.Floor((double)timeDelta.Days / 365.24D)) + " years ago"; }
            });
            timeRanges.Sort();
        }
        public static string GetRelativeTimeMessage(TimeSpan ago)
        {
            RelativeTimeRange postRelativeDateRange = timeRanges[0];
            foreach (var timeRange in timeRanges)
            {
                if (ago.CompareTo(timeRange.UpperBound) <= 0)
                {
                    postRelativeDateRange = timeRange;
                }
            }
            return postRelativeDateRange.RelativeTimeMessage(ago);
        }
    }
