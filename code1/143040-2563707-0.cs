    public class WeirdDateTime
    {
        public DateTime DateTimeUtc { get; set; }
    
        public WeirdDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            DateTimeUtc = weirdToUtc(year, month, day, hour, minute, second);
        }
    
        public WeirdDateTime(string s)
        {
            Regex regex = new Regex(@"(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})");
            Match match = regex.Match(s);
            if (!match.Success)
                throw new ArgumentException("Not a valid WeirdDateTime", "s");
    
            int[] parts = match.Groups
                .Cast<Group>()
                .Skip(1)
                .Select(x => int.Parse(x.Value))
                .ToArray();
    
            int year = parts[0];
            int month = parts[1];
            int day = parts[2];
            int hour = parts[3];
            int minute = parts[4];
            int second = parts[5];
    
            DateTimeUtc = weirdToUtc(year, month, day, hour, minute, second);
        }
    
        private DateTime weirdToUtc(int year, int month, int day, int hour, int minute, int second)
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
    
            DateTime dateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Local);
            if (addDay)
                dateTime = dateTime.AddDays(1);
    
            return dateTime.ToUniversalTime();
        }
    
        public override string ToString()
        {
            throw new NotImplementedException("Write this!");
        }
    }
