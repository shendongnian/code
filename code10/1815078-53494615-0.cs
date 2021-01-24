    public class EdiPartnersFactory : ServiceHostFactory
    {
       protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
       {
        // Initialize Automapper
        AutomapBootstrap.InitializeMap();
        var host = new ServiceHost(serviceType, baseAddresses);
        return host;
        }
    }
