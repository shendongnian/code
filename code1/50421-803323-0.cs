    public class ServiceProvider
    {
        public void Connect(Uri address)
        {
            //connect to the server
        }
    } 
    
    public class SettingsProvider
    {
       public void SaveAddress(Uri address)
       {
           //Persist address
       }
    
       public Uri LoadAddress()
       {
           //Get address from storage
       }
    }
    
    public class ConnectionViewModel 
    {
        private ServiceProvider serviceProvider;
    
        public ConnectionViewModel(ServiceProvider provider)
        {
            this.serviceProvider = serviceProvider;
        }
    
        public void ExecuteConnectCommand()
        {
            serviceProvider.Connect(Address);
        }        
    }
