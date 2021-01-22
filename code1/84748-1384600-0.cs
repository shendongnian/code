    abstract public class TestControllerBase : IDisposable
    {
        public TestDataContext CurrentDataContext { get; private set; }
        protected TestControllerBase()
        {
            CurrentDataContext = new TestDataContext();
        }
        protected TestControllerBase(TestDataContext dataContext)
        {
            CurrentDataContext = dataContext;
        }
        protected void ClearDataContext()
        {
            CurrentDataContext.Dispose();
            CurrentDataContext = new TestDataContext();
        }
        public void Dispose()
        {
            CurrentDataContext.Dispose();
        }
    }
