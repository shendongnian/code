    public class LogEvent
    {
        public static readonly LogEvent BuildingCommandObject = new LogEvent(1,
             "Building command object from {0}");
        // etc
        private readonly int id;
        private readonly string format;
        // Add the description if you want
        private LogEvent(int id, string format)
        {
            this.id = id;
            this.format = format;
        }
        public void Log(params object[] data)
        {
            string message = string.Format(format, data);
            // Do the logging here
        }
    }
