        public ServiceName()
        {
            //constructor code goes here
        }
        protected override void OnStart(string[] args)
        {
            ExecuteDelegate ed = new ExecuteDelegate(Execute);
            AsyncCallback ac = new AsyncCallback(EndExecution);
            IAsyncResult ar = ed.BeginInvoke(ac, ed);
            Log.WriteEntry("Service has started.");
        }
        protected void EndExecution(IAsyncResult ar)
        {
            ExecuteDelegate ed = (ExecuteDelegate)ar.AsyncState;
            ed.EndInvoke(ar);
            Stop();
            Log.WriteEntry("Service has stopped.");
        }
        protected void Execute()
        {
           //Code goes here
           ...
        }
        protected override void OnStop()
        {
            Log.WriteEntry("Service has stopped.");
        }
