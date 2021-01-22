    public static class BackgroundTaskRunner
    {     
        public static void FireAndForgetTask(Action action)
        {
            HostingEnvironment.QueueBackgroundWorkItem(cancellationToken => // .Net 4.5.2+ required
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    // TODO: handle exception
                }
            });
        }
        /// <summary>
        /// Using async
        /// </summary>
        public static void FireAndForgetTaskAsync(Func<Task> action)
        {
            HostingEnvironment.QueueBackgroundWorkItem(async cancellationToken => // .Net 4.5.2+ required
            {
                try
                {
                    await action();
                }
                catch (Exception e)
                {
                    // TODO: handle exception
                }
            });
        }
    }
