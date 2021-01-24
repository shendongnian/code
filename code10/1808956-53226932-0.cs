    public static string GetLogFile()
    {
        var fileTarget = LogManager.Configuration.AllTargets.OfType<FileTarget>().FirstOrDefault(t=>t.Name == "LogName");            
        return fileTarget?.FileName.Render(new LogEventInfo { Level = LogLevel.Info }) ?? string.Empty;
    }
