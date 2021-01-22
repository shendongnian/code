    private static volatile FileWriteTest instance;
    private static object syncRoot = new Object();
    private static Queue logMessages = new Queue();
    private static ErrorLogger oNetLogger = new ErrorLogger();
    private FileWriteTest() { }
    public static FileWriteTest Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new FileWriteTest();
                        Thread MyThread = new Thread(new ThreadStart(StartCollectingLogs));
                        MyThread.Start();
                    }
                }
            }
            return instance;
        }
    }
    private static void StartCollectingLogs()
    {
        //Infinite loop
        while (true)
        {
            cdoLogMessage objMessage = new cdoLogMessage();
            if (logMessages.Count != 0)
            {
                objMessage = (cdoLogMessage)logMessages.Dequeue();
                oNetLogger.WriteLog(objMessage.LogText, objMessage.SeverityLevel);
            }
        }
    }
    public void WriteLog(string logText, SeverityLevel errorSeverity)
    {
        cdoLogMessage objMessage = new cdoLogMessage();
        objMessage.LogText = logText;
        objMessage.SeverityLevel = errorSeverity;
        logMessages.Enqueue(objMessage);
    
    }
 
