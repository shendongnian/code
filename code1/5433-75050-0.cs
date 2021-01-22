    public class AClass
    {
        public void SomeMethod()
        {
            DoSomething();
    
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                BClass.WorkerMethod();
                SomeOtherMethod();
            });
    
            DoSomethingElse();
        }
    
        private void SomeOtherMethod()
        {
            // handle the fact that WorkerMethod has completed. 
            // Note that this is called on the Worker Thread, not
            // the main thread.
        }
    }
