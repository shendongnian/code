    public WriteToLog(string logMessage, LogCategory category)
    {
        switch(category)
        {
            case LogCategory.Info:
                // write to Info.log.txt
                break;
            case LogCategory.Error:
            case LogCategory.Fatal:
                // write to Error.log.txt
                break;
            case LogCategory.Debug:
                // write to Debug.log.txt
                break;
            default:
                // validate more
                break;
        }
    }
