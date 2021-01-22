    public class SomeThread : IDisposable 
    { 
        private object locker = new object(); 
        private RunState running = RunState.Stopped;
     
        public enum RunState
        {
            Stopped,
            Starting,
            Running,
            Stopping,
        }
            
        public RunState Running  
        {  
            get 
            { 
                lock(locker) 
                { 
                    return running; 
                } 
            } 
            set 
            { 
                lock(locker) 
                { 
                    running = value; 
                } 
            } 
        } 
     
        public void Run() 
        { 
            while (Running == RunState.Running) 
            { 
                lock(locker) 
                { 
                    DoSomething1(); 
                    DoSomething2(); 
                } 
            } 
            Dispose();
        
        } 
     
        private void DoSomething1() 
        { 
            // something awesome happens here 
        } 
     
        private void DoSomething2() 
        { 
            // something more awesome happens here 
        } 
     
        public void Dispose() 
        { 
            lock (locker) 
            {    
                Dispose1(); 
                Dispose2(); 
            } 
            Running = RunState.Stopped;
        } 
     
        private void Dispose1() 
        { 
            // something awesome happens here 
        } 
     
        private void Dispose2() 
        { 
            // something more awesome happens here 
        } 
     
    } 
     
    public class OtherThread 
    { 
        SomeThread st = new SomeThread(); 
     
        public void OnQuit() 
        { 
            st.Running = SomeThread.RunState.Stopping; 
            while (st.Running == SomeThread.RunState.Stopping) 
            {                 
                // Do something while waiting for the other thread.
            }  
     
            Exit(); 
        } 
    } 
