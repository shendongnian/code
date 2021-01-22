    private static void ConfigureLog4Net()
    {
    Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
    if(hierarchy != null &amp;&amp; hierarchy.Configured)
    {
        foreach(IAppender appender in hierarchy.GetAppenders())
        {
           if(appender is AdoNetAppender)
           {
               var adoNetAppender = (AdoNetAppender)appender;
               adoNetAppender.ConnectionString = ConfigurationManager.AppSettings["YOURCONNECTIONSTRINGKEY"].ToString();
               adoNetAppender.ActivateOptions(); //Refresh AdoNetAppenders Settings
           }
        }
    }
    }
