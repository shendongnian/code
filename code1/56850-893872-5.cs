        public static void AllToConsoleSetup()
        {
            var x = new log4net.Appender.ConsoleAppender { Layout = new log4net.Layout.SimpleLayout() };
            log4net.Config.BasicConfigurator.Configure(x);
            SetupDone = true;
        }
        public static void ShowOnlyLogOf(Type t)
        {
            var filter = new log4net.Filter.LoggerMatchFilter {LoggerToMatch = t.ToString(), AcceptOnMatch = true};
            var filterDeny = new log4net.Filter.DenyAllFilter();
            var x = new log4net.Appender.ConsoleAppender {Layout = new log4net.Layout.SimpleLayout()};
            x.AddFilter(filter);
            x.AddFilter(filterDeny);
            log4net.Config.BasicConfigurator.Configure(x);
            SetupDone = true;
        }
