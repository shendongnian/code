    public class TimeOffsetManager
    {
        public TimeOffsetManager()
        {
            InitialDateTime = DateTime.Now;
        }
        public DateTime InitialDateTime { get; private set; }
        public int GetOffset()
        {
            TimeSpan elapsed = DateTime.Now - InitialDateTime;
            return (int)Math.Round(elapsed.TotalMilliseconds);
        }
        public DateTime OffsetToDateTime(int offset)
        {
            return InitialDateTime + TimeSpan.FromMilliseconds(offset);
        }
    }
