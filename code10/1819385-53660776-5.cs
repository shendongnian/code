        void Application_Start(object sender, EventArgs e)    
        {
            ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(repository, new FileInfo(Server.MapPath("log4net.config")));
            
            // Remaining startup code.
        }
