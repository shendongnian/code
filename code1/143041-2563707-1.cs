    class WeirdDateTime
    {
        public DateTime DateTime { get; set; }
    
        public WeirdDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
        {
            if (hour < 6 || hour >= 30)
                throw new ArgumentException("Not a valid WeirdDateTime", "hour");
    
            bool addDay;
            if (hour > 23)
            {
                addDay = true;
                hour -= 24;
            }
            else
            {
                addDay = false;
            }
    
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, kind);
            if (addDay)
                dateTime = dateTime.AddDays(1);
    
            DateTime = dateTime;
        }
    
        public static WeirdDateTime Parse(string s)
        {
            Regex regex = new Regex(@"(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})");
            Match match = regex.Match(s);
            if (!match.Success)
                throw new ArgumentException("Not a valid WeirdDateTime", "s");
    
            int[] parts = match.Groups.Cast<Group>()
                .Skip(1)
                .Select(x => int.Parse(x.Value))
                .ToArray();
    
            int year = parts[0];
            int month = parts[1];
            int day = parts[2];
            int hour = parts[3];
            int minute = parts[4];
            int second = parts[5];
    
            return new WeirdDateTime(year, month, day, hour, minute, second, DateTimeKind.Unspecified);
        }
    
        public override string ToString()
        {
            throw new NotImplementedException("Write this!");
        }
    }
    
    class Program
    {
        public static void Main()
        {
            WeirdDateTime weirdDateTime = WeirdDateTime.Parse("2010-01-19 27:00:00");
            DateTime dateTimeUtc = weirdDateTime.DateTime.ToUniversalTime();
            Console.WriteLine(dateTimeUtc);
        }
    }
