    static public Logger.Textlog Logging { get; } = new Logger.Textlog();
    ...
    foreach (ParameterInfo pi in paramInfo)
    {
    	paramToPass = new object[] { Logging };
    }
