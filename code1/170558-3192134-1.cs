     log4net.Repository.Hierarchy.Hierarchy hier = log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
            if (hier != null)
            {
                //get ADONetAppender
                log4net.Appender.AdoNetAppender adoAppender =
                  (log4net.Appender.AdoNetAppender)hier.GetLogger("ADONetAppender",
                    hier.LoggerFactory).GetAppender("ADONetAppender");
                if (adoAppender != null)
                {
                    adoAppender.ConnectionString =
                      System.Configuration.ConfigurationSettings.AppSettings["MyConnectionString"];
                    adoAppender.ActivateOptions(); //refresh settings of appender
                }
            }
