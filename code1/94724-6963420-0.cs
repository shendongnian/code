    XmlConfigurator.Configure();
    log4net.Repository.Hierarchy.Hierarchy h =
    (log4net.Repository.Hierarchy.Hierarchy) LogManager.GetRepository();
    foreach (IAppender a in h.Root.Appenders)
    {
        if (a is FileAppender)
        {
            FileAppender fa = (FileAppender)a;
            // Programmatically set this to the desired location here
            string logFileLocation = @"C:\MySpecialFolder\MyFile.log";
            // Uncomment the lines below if you want to retain the base file name
            // and change the folder name...
            //FileInfo fileInfo = new FileInfo(fa.File);
            //logFileLocation = string.Format(@"C:\MySpecialFolder\{0}", fileInfo.Name);
            fa.File = logFileLocation;
            fa.ActivateOptions();
            break;
        }
    }
