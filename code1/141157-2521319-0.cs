    public class Model
    {
        public TimeSpan Time1 { get; set; }
        public TimeSpan Time2 { get; set; }
        public TimeSpan Time3 { get; set; }
        public TimeSpan Time4 { get; set; }
    
        public TimeSpan GetSpan(TimeSpan time)
        {
            var times = new[] { Time1, Time2, Time3, Time4 };
    
            return Enumerable.Range(1, times.Length - 1)
                .Select(i => new[] { times[i - 1], times[i] })
                .Where(t => t[0] <= time && time < t[1])
                .Select(t => t[1] - t[0])
                .FirstOrDefault();
        }
    }
