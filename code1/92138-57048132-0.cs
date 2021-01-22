    public class Time
    {
        public static void Timestamps()
        {
            OutputTimestamp();
            Thread.Sleep(1000);
            OutputTimestamp();
        }
        private static void OutputTimestamp()
        {
            var timestamp = DateTime.UtcNow.Ticks;
            var localTicks = DateTime.Now.Ticks;
            var localTime = new DateTime(timestamp, DateTimeKind.Utc).ToLocalTime();
            Console.Out.WriteLine("Timestamp = {0}.  Local ticks = {1}.  Local time = {2}.", timestamp, localTicks, localTime);
        }
    }
