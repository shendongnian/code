    public static class StopWatchExtensions
    {
        public static async Task<TimeSpan> LogElapsedMillisecondsAsync(
            this Stopwatch stopwatch,
            ILogger logger,
            string actionName,
            Func<Task> action)
        {
            stopwatch.Reset();
            stopwatch.Start();
    
            await action();
    
            stopwatch.Stop();
    
            logger.LogDebug(string.Format(actionName + " completed in {0}.", stopwatch.Elapsed.ToString("hh\\:mm\\:ss")));
    
            return stopwatch.Elapsed;
        }
    }
