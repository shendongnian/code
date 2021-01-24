    public class YourWCFServiceFactory: ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
            host.Opening += new EventHandler(host_Opening);
            host.Closing += new EventHandler(host_Closing);
            return host;
        }
    
        private void host_Opening(object sender, EventArgs e)
        {
            // Initialization here
        }
        private void host_Opening(object sender, EventArgs e)
        {
            // Cleanup here
        }
    }
