    /// <summary>
    /// Applies a transformation to the filenames of all FileAppenders.
    /// </summary>
    public static void ChangeLogFile(Func<string,string> transformPath)
    {
        // iterate over all FileAppenders
        foreach (var fileAppender in LogManager.GetRepository().GetAppenders().OfType<FileAppender>())
        {
            // apply transformation to the filename
            fileAppender.File = transformPath(fileAppender.File);
            // notify the logging subsystem of the configuration change
            fileAppender.ActivateOptions();
        }
    }
