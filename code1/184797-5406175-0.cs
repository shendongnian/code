        public void Init()
        {
            if (mew == null)
            {
                mew = new ManagementEventWatcher(query);
                mew.EventArrived += mew_EventArrived;
                mew.Start();
            }
        }
        public void TearDown()
        {
            if (mew != null)
            {
                mew.Stop();
                mew.Dispose();
                mew = null;
            }
        }
