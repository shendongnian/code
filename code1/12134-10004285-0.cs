    public class ServiceHost
    {
        private static Logger log = LogManager.GetLogger(typeof(ServiceHost).Name);
        private static ServiceHost mInstance = null;
        private static object mSyncRoot = new object();
        #region Singleton and Static Properties
        public static ServiceHost Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mSyncRoot)
                    {
                        if (mInstance == null)
                        {
                            mInstance = new ServiceHost();
                        }
                    }
                }
                return (mInstance);
            }
        }
        public static Logger Log
        {
            get { return log; }
        }
        public static void Close()
        {
            lock (mSyncRoot)
            {
                if (mInstance.mEngine != null)
                    mInstance.mEngine.Dispose();
            }
        }
        #endregion
        private ReconciliationEngine mEngine;
        private ServiceBase windowsServiceHost;
        private UnhandledExceptionEventHandler threadExceptionHanlder = new UnhandledExceptionEventHandler(ThreadExceptionHandler);
        public bool HostHealthy { get; private set; }
        public bool RunningAsService {get; private set;}
        private ServiceHost()
        {
            HostHealthy = false;
            RunningAsService = false;
            AppDomain.CurrentDomain.UnhandledException += threadExceptionHandler;
            try
            {
                mEngine = new ReconciliationEngine();
                HostHealthy = true;
            }
            catch (Exception ex)
            {
                log.FatalException("Could not initialize components.", ex);
            }
        }
        public void StartService()
        {
            if (!HostHealthy)
                throw new ApplicationException("Did not initialize components.");
            try
            {
                mEngine.Start();
            }
            catch (Exception ex)
            {
                log.FatalException("Could not start service components.", ex);
                HostHealthy = false;
            }
        }
        public void StartService(ServiceBase serviceHost)
        {
            if (!HostHealthy)
                throw new ApplicationException("Did not initialize components.");
            if (serviceHost == null)
                throw new ArgumentNullException("serviceHost");
            windowsServiceHost = serviceHost;
            RunningAsService = true;
            try
            {
                mEngine.Start();
            }
            catch (Exception ex)
            {
                log.FatalException("Could not start service components.", ex);
                HostHealthy = false;
            }
        }
        public void RestartService()
        {
            if (!HostHealthy)
                throw new ApplicationException("Did not initialize components.");         
            try
            {
                log.Info("Stopping service components...");
                mEngine.Stop();
                mEngine.Dispose();
                log.Info("Starting service components...");
                mEngine = new ReconciliationEngine();
                mEngine.Start();
            }
            catch (Exception ex)
            {
                log.FatalException("Could not restart components.", ex);
                HostHealthy = false;
            }
        }
        public void StopService()
        {
            try
            {
                if (mEngine != null)
                    mEngine.Stop();
            }
            catch (Exception ex)
            {
                log.FatalException("Error stopping components.", ex);
                HostHealthy = false;
            }
            finally
            {
                if (windowsServiceHost != null)
                    windowsServiceHost.Stop();
                if (RunningAsService)
                {
                    AppDomain.CurrentDomain.UnhandledException -= threadExceptionHanlder;
                }
            }
        }
        private void HandleExceptionBasedOnExecution(object ex)
        {
            if (RunningAsService)
            {
                windowsServiceHost.Stop();
            }
            else
            {
                throw (Exception)ex;
            }
        }
        protected static void ThreadExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            log.FatalException("Unexpected error occurred. System is shutting down.", (Exception)e.ExceptionObject);
            ServiceHost.Instance.HandleExceptionBasedOnExecution((Exception)e.ExceptionObject);
        }
    }
