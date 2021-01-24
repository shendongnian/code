    public class HeartbeatSetup
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Heartbeat()
        {
            try
            {
                RecurringJob.AddOrUpdate("heartbeat", () => Fire(), Cron.Minutely);
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "error");
                throw;
            }
        }
        public static void Fire()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logFile = new NLog.Targets.FileTarget("logfile") { FileName = "heartbeat.txt" };
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logFile);
            NLog.LogManager.Configuration = config;
            var currentTime = DateTime.Now.ToString();
            try
            {
                logger.Info(currentTime + " - beep");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex + " - beeeeeeeeeeeeeeeeeeeeeeeeeeeeeep");
            }
        }
    }
