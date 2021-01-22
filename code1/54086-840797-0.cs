    public static class LoggerExtentions
    {
        public static void StartTimerLogInformation(this Logger logger, Stopwatch stopWatch, string method)
        {
            stopWatch.Reset();
            stopWatch.Start();
            logger.LogInformation(string.Format("Calling {0} at {1}", method, DateTime.Now.ToString()));
        }        
        public static void StopTimerLogInformation(this Logger logger, Stopwatch stopWatch, string method)
        {
            stopWatch.Stop();
            logger.LogInformation(string.Format("{0} returned at {1}", method, DateTime.Now.ToString()));
            logger.LogInformation(string.Format("{0} took {1} milliseconds", method, stopWatch.ElapsedMilliseconds));
            stopWatch.Reset();
        }
    }
