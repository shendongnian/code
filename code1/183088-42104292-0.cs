        public static TraceListenerData GetTraceListener(string name)
        {
            var log = ConfigurationManager.GetSection("loggingConfiguration") as LoggingSettings;
            return log.TraceListeners.Single(tl => tl.Name == name);
        }
