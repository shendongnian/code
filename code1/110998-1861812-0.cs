    public class MasterClass
    {
        private MyClass myClass;
        private object syncRoot = new object(); // this is what we'll use to synchronize the code
    
        public void Thread1Proc()
        {
            lock(syncRoot)
            {
                myClass = new MyClass();
            }
        }
    
        public void Thread2Proc()
        {
            lock(syncRoot)
            {
                myClas.SomeMethodCalledFromAnotherThread();
            }
        }
    }
