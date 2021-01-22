    //untested
    public abstract class BgHelper
    {
        public System.Exception Error { get; private set; }
        public System.Object State { get; private set; }
        
        public void RunMe(object state)
        {
            this.State = state;
            this.Error = null;
            
            ThreadStart starter = new ThreadStart(Run);
            Thread t = new Thread(starter);
            t.Start();            
        }
    
        private void Run()
        {
            try
            {
                DoWork();                
            }
            catch (Exception ex)
            {
                Error = ex;
            }
            Completed(); // should check Error first
        }
    
        protected abstract void DoWork() ;
    
        protected abstract void Completed();
    }
