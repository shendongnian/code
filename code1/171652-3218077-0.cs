    class CommandHandler
    {
        Action nextCommand;
        ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        object lockObject = new object();
        public CommandHandler()
        {
            new Thread(ProcessCommands).Start();                       
        }
        public void AddCommand(Action nextCommandToProcess)
        {
            lock (lockObject)
            {
                nextCommand = nextCommandToProcess;
            }
            manualResetEvent.Set();
        }
        private void ProcessCommands()
        {
            while (true)
            {
                Action action = null;
                lock (lockObject)
                {
                    action = nextCommand;
                    nextCommand = null;
                }
                if (action != null)
                {
                    action();
                }
                lock (lockObject)
                {
                    if(nextCommand != null)
                        continue;
                    manualResetEvent.Reset();
                }
                manualResetEvent.WaitOne();
            }
        }
    }
