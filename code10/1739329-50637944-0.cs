        public class QuartzSchedulerListener : ISchedulerListener//todo R & D to catch schdeuler error/invalid shutdown event and do possible implementation there
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobScheduled");
            });
            return t;
        }
        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobUnscheduled");
            });
            return t;
        }
        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler TriggerFinalized");
            });
            return t;
        }
        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler TriggerPaused");
            });
            return t;
        }
        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.DebugFormat("Quartz Scheduler TriggersPaused {0}", triggerGroup);
            });
            return t;
        }
        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler TriggersPaused");
            });
            return t;
        }
        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.DebugFormat("Quartz Scheduler TriggersResumed {0}", triggerGroup);
            });
            return t;
        }
        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobAdded");
            });
            return t;
        }
        public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobDeleted");
            });
            return t;
        }
        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobPaused");
            });
            return t;
        }
        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobInterrupted");
            });
            return t;
        }
        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.DebugFormat("Quartz Scheduler JobsPaused {0}", jobGroup);
            });
            return t;
        }
        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler JobResumed");
            });
            return t;
        }
        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.DebugFormat("Quartz Scheduler JobsResumed {0}",jobGroup);
            });
            return t;
        }
        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.DebugFormat("Quartz Scheduler is Error State message:{0}", msg);
                if (cause != null)
                {
                    Logger.Error(cause);
                }
            });
            return t;
        }
        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler is in Stand By Mode");
            });
            return t;
        }
        public Task SchedulerStarted(CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler is Started");
            });
            return t;
        }
        public Task SchedulerStarting(CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler is Starting");
            });
            return t;
        }
        public Task SchedulerShutdown(CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler is Shut Down");
            });
            return t;
        }
        public Task SchedulerShuttingdown(CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler is Shutting Down");
            });
            return t;
        }
        public Task SchedulingDataCleared(CancellationToken cancellationToken = default(CancellationToken))
        {
            var t = Task.Factory.StartNew
            (() =>
            {
                Logger.Debug("Quartz Scheduler SchedulingDataCleared");
            });
            return t;
        }
    }
      StdSchedulerFactory factory = new StdSchedulerFactory();
                    var MyQuartzScheduler = await factory.GetScheduler();
                    QuartzSchedulerListener olistener = new QuartzSchedulerListener();
                    MyQuartzScheduler.ListenerManager.AddSchedulerListener(olistener);
                    await MyQuartzScheduler.Start();
