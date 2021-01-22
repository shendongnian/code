    ///<Summary>
    /// To write a log <Anycomment as per your code>
    ///</Summary>
    public EventLogger()
    {
        LogFile = string.Format("{0}{1}", LogFilePath, FileName);
    }
