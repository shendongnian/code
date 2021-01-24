    Thread thr = new Thread((new ThreadStart(() => CheckFile())));
    thr.Start();
    bool m_isToKeepChecking = true;
    private void CheckFile()
    {
        DateTime previousTime = DateTime.Now;
        while(m_isToKeepChecking)
        {
            DateTime currTime = File.GetLastWriteTime("some Path");
            if(currTime >previousTime)
            {
               previousTime = currTime;
               //Raise your event to handle the change;
            }
        }
    }
