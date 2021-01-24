    public class Utility
    {
        public static EventAggregator EventAggregator { get; set; }
        static Utility()
        {
            EventAggregator = new EventAggregator();
        }
    }
