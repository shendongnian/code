	LogManager.Configuration.AddTarget(t1);
	LogManager.Configuration.AddTarget(t2);
	LoggingRule r1 = new LoggingRule("*", LogLevel.Debug, t1);
	LoggingRule r2 = new LoggingRule("*", LogLevel.Trace, t2);
	LogManager.Configuration.LoggingRules.Add(t1);
	LogManager.Configuration.LoggingRules.Add(t2);
	LogManager.Configuration.Reload();
