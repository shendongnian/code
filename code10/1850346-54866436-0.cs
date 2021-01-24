    public class EventData
    {
        public string Start { get; set; }
        public string End { get; set; }
        public TimeSpan CalculateDuration()
        {
            if (String.IsNullOrEmpty(Start)
               || String.IsNullOrEmpty(End))
            {
                // What should happen, if start or end is not set?
            }
            // What should happen, if parsing fails?
            var start = DateTime.Parse(Start);
            var end = DateTime.Parse(End);
            // What should happen, if start is later then end??
            return end - start;
        }
        public override string ToString()
        {
            return $"{Start} - {End} => {CalculateDuration()}";
        }
    }
    private static readonly Random random = new Random();
    private static EventData CreateSample()
    {
        var now = DateTime.UtcNow;
        var start = now.AddSeconds(random.Next(1000));
        var end = start.AddSeconds(random.Next(1000));
        return new EventData
        {
            Start = start.ToString(),
            End = end.ToString()
        };
    }
