    class ConfWizard {
        private ManualResetEvent _init = new ManualResetEvent(false);
    	
        public ConfWizard() {
           var h = new HelperClass();
           h.ReadyEvent += this.helper_ReadyEvent;
           h.StartUp();
    		
           do {
              Application.DoEvents();
           } while (!_init.WaitOne(1000));
       }	
    
       private void helper_ReadyEvent() {
           _init.Set();
       }
    }
    class HelperClass {
       public event Action ReadyEvent;
   
       public void StartUp() {
          ThreadPool.QueueUserWorkItem(s => {
             Thread.Sleep(10000);
             var e = this.ReadyEvent;
             if (e != null) e();
          });
       }
    }
