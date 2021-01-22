        public abstract class RipperBase : IRipper
        {
            public void Rip( Filestream fs )
            {
                 RipCore (fs);
                 OnCompleted();
            }
        
            protected abstract void RipCore(Filestream fs);
        
            public event EventHandler<RipperEventArgs> Completed;
        
            protected void OnCompleted
            {
               if( Completed != null )
               {
                   // TODO: make this Threadsafe.
                   Completed (this, new RipperEventArgs( ... ) );
               }
            }
    }
