        public  class Executor
    {
        private readonly Action mainActionDelegate;
        private readonly Action onFaultDelegate;
        public Executor(Action mainAction, Action onFault)
        {
            mainActionDelegate = mainAction;
            onFaultDelegate = onFault;
        }
        public  void Run()
        {
            bool bad = true;
            try
            {
                mainActionDelegate();
                bad = false;
            }
            finally
            {
                if(bad)
                {
                    onFaultDelegate();
                }
            }
        }
    }
