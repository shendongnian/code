        System.Threading.Thread MainThread { get; set; } = null;
        protected override void OnStart(string[] args)
        {
            MainThread = new System.Threading.Thread(new System.Threading.ThreadStart(new Action(()=>{
                // Put your codes here ... 
            })));
            MainThread.Start();
        }
        protected override void OnStop()
        {
            MainThread?.Abort();
        }
