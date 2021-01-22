    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class RelativeDateHelper
    {
        private static Dictionary<double, Func<double, string>> sm_Dict = null;
    
        private static Dictionary<double, Func<double, string>> DictionarySetup()
        {
            var dict = new Dictionary<double, Func<double, string>>();
            dict.Add(0.75, (mins) => "less than a minute");
            dict.Add(1.5, (mins) => "about a minute");
            dict.Add(45, (mins) => string.Format("{0} minutes", Math.Round(mins)));
            dict.Add(90, (mins) => "about an hour");
            dict.Add(1440, (mins) => string.Format("about {0} hours", Math.Round(Math.Abs(mins / 60)))); // 60 * 24
            dict.Add(2880, (mins) => "a day"); // 60 * 48
            dict.Add(43200, (mins) => string.Format("{0} days", Math.Floor(Math.Abs(mins / 1440)))); // 60 * 24 * 30
            dict.Add(86400, (mins) => "about a month"); // 60 * 24 * 60
            dict.Add(525600, (mins) => string.Format("{0} months", Math.Floor(Math.Abs(mins / 43200)))); // 60 * 24 * 365 
            dict.Add(1051200, (mins) => "about a year"); // 60 * 24 * 365 * 2
            dict.Add(double.MaxValue, (mins) => string.Format("{0} years", Math.Floor(Math.Abs(mins / 525600))));
        
            return dict;
        }
    
        public static string ToRelativeDate(this DateTime input)
        {
            TimeSpan oSpan = DateTime.Now.Subtract(input);
            double TotalMinutes = oSpan.TotalMinutes;
            string Suffix = " ago";
    
            if (TotalMinutes < 0.0)
            {
                TotalMinutes = Math.Abs(TotalMinutes);
                Suffix = " from now";
            }
            if (null == sm_Dict)
                sm_Dict = DictionarySetup();
            return sm_Dict.First(n => TotalMinutes < n.Key).Value.Invoke(TotalMinutes) + Suffix;
        }
    }
