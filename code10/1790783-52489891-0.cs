    public class MyProcess
    {
        public event EventHandler<NetworkShareDisconnectedEventArgs> InBoxShareDisconnected;
    
        public MyProcess()
        {
            //This doesn't really do anything, don't raise events here, nothing will be
            //subscribed yet, so nothing will get it.
        }
        
        //Guessing at the argument types here
        public void Disconnect(object path, DateTime timestamp, bool connected)
        {
            RaiseEvent(new NetworkShareDisconnectedEventArgs(path, timestamp, connected));
        }
    
        protected void RaiseEvent(NetworkShareDisconnectedEventArgs e)
        {
            InBoxShareDisconnected?.Invoke(this, e);
        }
    }
