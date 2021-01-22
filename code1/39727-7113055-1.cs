    public class WcfPingTest : IWcfPingTest
    {
      public const string magicString = "djeut73bch58sb4"; // this is random, just to see if you get the right result
      public string Ping() {return magicString;}
    }
    public void WcfTestHost_Open()
    {
      string hostname = System.Environment.MachineName;
      var baseAddress = new UriBuilder("http", hostname, 7400, "WcfPing");
      var h = new ServiceHost(typeof(WcfPingTest), baseAddress.Uri);
      // enable processing of discovery messages.  use UdpDiscoveryEndpoint to enable listening. use EndpointDiscoveryBehavior for fine control.
      h.Description.Behaviors.Add(new ServiceDiscoveryBehavior());
      h.AddServiceEndpoint(new UdpDiscoveryEndpoint());
      // enable wsdl, so you can use the service from WcfStorm, or other tools.
      var smb = new ServiceMetadataBehavior();
      smb.HttpGetEnabled = true;
      smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
      h.Description.Behaviors.Add(smb);
      // create endpoint
      var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
      h.AddServiceEndpoint(typeof(IWcfPingTest) , binding,   "");
      h.Open();
      Console.WriteLine("host open");
    }
