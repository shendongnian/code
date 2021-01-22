        var emailTraceListener = new EmailTraceListener("foo@bar.com", "foo@bar.com", "Food", "Bar",
                                                        "smtp.foo.bar") {Name = "EmailTraceListener"};
        LogSource logSource;
        Logger.Writer.TraceSources.TryGetValue("General", out logSource);
        logSource.Listeners.Add(emailTraceListener);
        var logEntry = new LogEntry {Message = "Test"};
        Logger.Write(logEntry);
