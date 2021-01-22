    internal class Sample
    {
        private static void Main(string[] args)
        {
            DelayedEvaluationLogger.Debug(logger, () => "This is " + Expensive() + " to log.");
        }
        private static string Expensive()
        {
            // ...
        }
    }
    internal static class DelayedEvaluationLogger
    {
        public static void Debug(ILog logger, Func<string> logString)
        {
            if (logger.isDebugEnabled)
            {
                logger.Debug(logString());
            }
        }
    }
