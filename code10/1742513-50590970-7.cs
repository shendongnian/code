    // This class provides callbacks to the host app domain.
    // This is optional, you need only if you want to send back some information
    public class DomainHost : MarshalByRefObject
    {
        // sends any object to the host. The object must be serializable
        public void SendDataToMainDomain(object data)
        {
            Console.WriteLine($"Hmm, some interesting data arrived: {data}");
        }
        // there is no timeout for host
        public override object InitializeLifetimeService() => null;
    }
