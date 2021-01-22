    public class MyClass : IDisposable
    {
        private MyDisposableMember member = new MyDisposableMember();
    
        public DoSomething
        {
             // Do things with member :)
        }
    
        ~MyClass()
        {
            Dispose(false);
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)  // Release managed resources
            {           
                member.Dispose();
            }
    
            // Release unmanaged resources
        }
    }
