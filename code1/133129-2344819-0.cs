    public class Item : IDisposable // I know it is a horrible class name...
    {
        private readonly ManualResetEvent accessibleEvent = new ManualResetEvent(true);
    
        public void Extract()
        {
            try
            {
                accessibleEvent.Reset(); // lock  
                // .....
            }
            finally
            {
                accessibleEvent.Set(); // unlock             
            }
        }
    
        public void Edit()
        {
            if (!accessibleEvent.WaitOne(1000)) // wait 1 second
            {
                // notify user?    
            }
        
            // ....
        }
    
        public void Dispose()
        {
            ((IDisposable)accessibleEvent).Dispose();
        }
    }
