    public partial class WindowsServiceToHostASMXWebService  : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            Uri address = new Uri("soap.tcp://localhost/TestService");
            SoapReceivers.Add(new EndpointReference(address), typeof(Service ));
        }
        protected override void OnStop()
        {
            SoapReceivers.Clear();
        }
    }
