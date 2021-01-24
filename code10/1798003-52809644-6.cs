    public class Bootstrapper {
        public IKernel Init() {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IServiceProvider>().ToConstant(kernel);
            return kernel;
        }
    }
    public class LoggingModule : NinjectModule {
        public override void Load() {
            Bind<ILog>()
                .ToMethod(x => LogManager.GetLogger(
                    x.Request.Target != null ? x.Request.Target.Member.DeclaringType : x.Request.Service)
                );
        }
    }
    public class QuartzModule : NinjectModule {
        public override void Load() {
            Bind<IJobFactory>().To<NinjectJobFactory>();
            Bind<ISchedulerFactory>().To<StdSchedulerFactory>();
            Bind<IService>().To<Service>();
        }
    }
    class NinjectJobFactory : IJobFactory {
        readonly IServiceProvider provider;
        public NinjectJobFactory(IServiceProvider provider) {
            this.provider = provider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobType = jobDetail.JobType;
            try {
                // this will inject any dependencies that the job requires
                var value = (IJob)provider.GetService(jobType);
                return value;
            } catch (Exception e) {
                throw new SchedulerException(string.Format("Problem while instantiating job '{0}' from the NinjectJobFactory.", bundle.JobDetail.Key), e);
            }
        }
        /// <summary>
	    /// Allows the job factory to destroy/cleanup the job if needed. 
	    /// No-op when using SimpleJobFactory.
	    /// </summary>
	    public void ReturnJob(IJob job) {
            var disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
