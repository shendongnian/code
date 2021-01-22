    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new StringTime("14:20 pm").Add(new StringTime("0:30 pm")));
            Console.WriteLine(new StringTime("15:00 pm").Add(new StringTime("0:30 pm")));
            Console.WriteLine(new StringTime("5:00am").Add(new StringTime("12:00pm")));
        }
    }
    class StringTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public bool IsAfternoon { get; set; }
        public StringTime(string timeString)
        {
            IsAfternoon = timeString.Contains("pm");
            timeString = timeString.Replace("pm", "").Replace("am", "").Trim();
            Hours = int.Parse(timeString.Split(':')[0]);
            Minutes = int.Parse(timeString.Split(':')[1]);
        }
        public TimeSpan ToTimeSpan()
        {
            if (IsAfternoon)
            {
                if (Hours < 12)
                {
                    Hours += 12;
                }
            }
            return new TimeSpan(Hours, Minutes, 00);
        }
        public TimeSpan Add(StringTime time2)
        {
            return this.ToTimeSpan().Add(time2.ToTimeSpan());
        }
    }
