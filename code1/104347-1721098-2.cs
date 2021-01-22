    private void Log(string message)
    {
        using (FileStream fs = new FileStream(@"c:\svclog.txt", FileMode.OpenOrCreate, FileAccess.Write)
        {
            using (using (StreamWriter m_streamWriter = new StreamWriter(fs)))
            {
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(message + " " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString());
                m_streamWriter.WriteLine(" *----------------*");
            }
        }
    }
    protected override void OnStart(string[] args)
    {
        Log("Service Started");
        tmrCallBack = new TimerCallback(goEXE);
        tmr = new Timer(tmrCallBack, null, 0, 1000 * 60 * 1 / 2);
    }
    protected override void OnStop()
    {
        Log("Service Stopped");
        tmr.Dispose();
    }
    private void goEXE(Object state)
    {
        Console.WriteLine(DateTime.Now.ToString());
        Log("Service running");
    }
