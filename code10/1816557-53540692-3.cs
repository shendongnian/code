    using NLog;
    using System.Threading;
    using System.Threading.Tasks;
    using NLog.Config;
    namespace ConsoleApplication2
    {
    class Program
    {
        private static readonly object LoggerSynchronization = new object();
        static void Main(string[] args)
        {
            //create some jobs
            int numberOfJobs = 5;
            for (int i = 0; i < numberOfJobs; i++)
            {
                var jobNumber = i;
                Task.Run(() => RunJob(jobNumber));
            }
            Thread.Sleep(1000); //wait till done
        }
        private static void RunJob(int jobNumber)
        {
            var logger = SetupLog(jobNumber);
            logger.Info($"Running job {jobNumber}.");
            //do stuff here ...
        }
        private static Logger SetupLog(int jobNumber)
        {
            var loggerName = $"Job{jobNumber}";
            //create a custom target per job
            var target = new NLog.Targets.FileTarget()
            {
                FileName = $"Arquivo{jobNumber}.Log",
                Name = $"logfile{jobNumber}",
                Layout = "${logger} ${longdate} ${level} ${message}",
            };
            //add the target to the configuration
            lock (LoggerSynchronization) //avoid concurrency issues between the jobs
            {
                //check if configuration exists
                if (NLog.LogManager.Configuration == null)
                {
                    NLog.LogManager.Configuration = new LoggingConfiguration();
                }
                var config = NLog.LogManager.Configuration;
                config.AddTarget(target);
                config.AddRuleForAllLevels(target, loggerName);
                NLog.LogManager.ReconfigExistingLoggers();
                NLog.LogManager.Configuration.Reload();
            }
            return NLog.LogManager.GetLogger(loggerName);
        }
    }
    }
