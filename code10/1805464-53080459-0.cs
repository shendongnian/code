    public abstract class BaseClass
    {
        public void DoWork()
        {
            Initialize();
            DoWorkImpl();
            CleanUp();
        }
   
        public abstract void DoWorkImpl();
        private void Initialize()
        {
           // Initialization code here.
        }
        private void Cleanup()
        {
           // Cleanup code here.
        }
    }
