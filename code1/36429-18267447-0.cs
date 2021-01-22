    public interface IServiceClientFactory<T>
    {
        T DoSomethingWithClient();
    }
    public partial class ServiceClient : IServiceClientFactory<ServiceClient>
    {
        public ServiceClient DoSomethingWithClient()
        {
            var client = this;
            // do somthing here as set client credentials, etc.
            //client.ClientCredentials = ... ;
            return client;
        }
    }
