    public static class LoggerExtensions
    {
        public static void LogWithStartTime(this Logger self, string message)
        {
            var startTime = Global.GetStartTime();
            self.Log($"{startTime}: ${message}");
        }
    }
