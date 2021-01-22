    public static string GetLogFileName(string name)
    {
         var rootAppender = LogManager.GetRepository()
                                      .GetAppenders()
                                      .OfType<FileAppender>()
                                      .FirstOrDefault(fa => fa.Name == name);
         return rootAppender != null ? rootAppender.File : string.Empty;
    }
