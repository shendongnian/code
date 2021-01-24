    public class CustomTimer : System.Timers.Timer
    {
        // Add this ↓
        public static ConcurrentDictionary<string, CustomTimer> Timers = new ConcurrentDictionary<string, CustomTimer>();
        // ...
    }
