    class customSchedulerClass : IDisposable
    {
        
        private Component component = new Component();
        private bool disposed = false;
        public void scheduleSomeStuff()
        {
            //This is where you would implement the Quartz.net stuff
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SupressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if(!this=disposed)
            {
                if(disposing)
                {
                    component.dispose;
                }
            }
            disposed = true;
        }       
    }
