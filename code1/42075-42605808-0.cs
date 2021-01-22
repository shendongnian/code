    public abstract class UiSynchronizeModel
    {
        private readonly TaskScheduler uiSyncContext;
        private readonly SynchronizationContext winformsOrDefaultContext;
        protected UiSynchronizeModel()
        {
            this.winformsOrDefaultContext = SynchronizationContext.Current ?? new SynchronizationContext();
            this.uiSyncContext = TaskScheduler.FromCurrentSynchronizationContext();
            this.UiContextScheduler = new SynchronizationContextScheduler(this.winformsOrDefaultContext);
        }
        protected SynchronizationContextScheduler UiContextScheduler { get; }
        protected void RunOnGuiThread(Action action)
        {
            this.winformsOrDefaultContext.Post(o => action(), null);
        }
        protected void CompleteTask(Task task, TaskContinuationOptions options, Action<Task> action)
        {
            task.ContinueWith(delegate
            {
                action(task);
                task.Dispose();
            }, CancellationToken.None, options, this.uiSyncContext);
        }
    }
