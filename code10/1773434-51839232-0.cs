    private static Logger logger = LogManager.GetCurrentClassLogger();
    public static void DashboardLogging(string username, string changedField, string oldValue, string newValue, string taskName)
        {
            try
            {
                LogManager.Configuration = new XmlLoggingConfiguration(AppDomain.CurrentDomain.BaseDirectory + "Views\\Dashboard\\Nlog.config");
                logger.Info(" User: " + username + " | Field Changed: " + changedField + " | Change: " + oldValue + " --> " + newValue + " | Affected Task: " + taskName);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "*ERROR*");
            }
        }
