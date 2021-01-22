Maybe this small tidbit might help you out:  you need to override the <b>RollingFileAppender</b> and after modifying the File property, invoke the ActivateOptions method, like below:
    var myPath = "C:\\";
    var log = LogManager.GetLogger(typeof(MySpecificAssembly).Name);
    XmlConfigurator.Configure();
    var rfa = (RollingFileAppender)LogManager.GetRepository().GetAppenders()
        .First(c => c.Name == "RollingFileAppender");
    rfa.File = myPath + typeof(MySpecificAssembly).Name + ".log";
    rfa.ActivateOptions();
