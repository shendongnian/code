    public class ServiceProvider
    {
        public event EventHandler<ConnectedEventArgs> Connected;
        public void Connect(Uri address)
        {
            //connect to the server
            if (Connected != null)
            {
                Connected(this, new ConnectedEventArgs(address));
            }
        }
    } 
    
    public class SettingsProvider
    {
       public SettingsProvider(ServiceProvider serviceProvider)
       {
           serviceProvider.Connected += serviceProvider_Connected;
       }
       protected virtual void serviceProvider_Connected(object sender, ConnectedEventArgs e)
       {
           SaveAddress(e.Address);
       }
       public void SaveAddress(Uri address)
       {
           //Persist address
       }
    
       public Uri LoadAddress()
       {
           //Get address from storage
       }
    }
