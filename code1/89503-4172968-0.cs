    Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
    hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/
    
    FileAppender fileAppender = new FileAppender();
    fileAppender.AppendToFile = true;
    fileAppender.LockingModel = new FileAppender.MinimalLock();
    fileAppender.File = Server.MapPath("/") + "log.txt";
    PatternLayout pl = new PatternLayout();
    pl.ConversionPattern = "%d [%2%t] %-5p [%-10c]   %m%n%n";
    pl.ActivateOptions();
    fileAppender.Layout = pl;
    fileAppender.ActivateOptions();
    
    log4net.Config.BasicConfigurator.Configure(fileAppender);
    
    //Test logger
    ILog log =LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    log.Debug("Testing!");
