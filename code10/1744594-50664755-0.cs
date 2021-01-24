    public class Context
    {
        public Context()
        {
            UniqueToken = new Guid();
            Logs = new List<string>();
        }        
        public Guid UniqueToken { get; }
        public DateTime ProcessStartedAt { get; set; }
        public DateTime ProcessEndedAt { get; set; }
        public long ProcessTimeInMilliseconds
        {
            get
            {
                return (long)ProcessEndedAt.Subtract(ProcessStartedAt).TotalMilliseconds;
            }
        }
        public List<string> Logs { get; set; }
    }
