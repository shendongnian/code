    public class DaoClass : IDisposable
    {
        MyModelContext context = new MyModelContext();
    
        public void DoSomething()
        {
            // use the context here
        }
    
        public void DoAnotherThing()
        {
            // use the context here
        }
    
        public void DoSomethingElse()
        {
            // use the context here
        }
    
        public void Dispose()
        {
            context.Dispose();
        }
    }
