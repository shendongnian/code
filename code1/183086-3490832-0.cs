    // Open config file
    ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
    fileMap.ExeConfigFilename = @"MyApp.exe.config";
    
    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
    
    // Get EL log settings
    LoggingSettings log = config.GetSection("loggingConfiguration") as LoggingSettings;
    
    // Get TraceListener info
    foreach(TraceListenerData listener in log.TraceListeners)
    {
        // Check for listener types you care about
        if (listener is RollingFlatFileTraceListenerData)
        {
            RollingFlatFileTraceListenerData data = listener as RollingFlatFileTraceListenerData;
            Console.WriteLine(string.Format("Found RollingFlatFileLIstener with Name={0}, FileName={1}, Header={2}, Footer={3}, RollSizeKB={4}, TimeStampPattern={5},RollFileExistsBehavior={6}, RollInterval={7}, TraceOutputOptions={8}, Formatter={9}, Filter={10}",
                data.Name, data.FileName, data.Header, data.Footer, data.RollSizeKB, 
                data.TimeStampPattern, data.RollFileExistsBehavior, data.RollInterval,
                data.TraceOutputOptions, data.Formatter, data.Filter);
        }
        else // other trace listener types e.g. FlatFileTraceListenerData 
        {
        }
    }
