        static Thread keepAliveThread = new Thread(KeepAlive);
        protected void Application_Start()
        {
            keepAliveThread.Start();
        }
        protected void Application_End()
        {
            keepAliveThread.Abort();
        }
        static void KeepAlive()
        {
            while (true)
            {
                WebRequest req = WebRequest.Create("http://www.mywebsite.com/DummyPage.aspx");
                req.GetResponse();
                try
                {
                    Thread.Sleep(60000);
                }
                catch (ThreadAbortException)
                {
                    break;
                }
            }
        }
