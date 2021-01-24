    namespace Your_Reference_Service_Namespace
    {
        public partial class Your_Reference_Service_Client
        {
            static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials)
            {
                serviceEndpoint.Address = 
                    new System.ServiceModel.EndpointAddress(new System.Uri("http://your_web_service_address"), 
                    new System.ServiceModel.DnsEndpointIdentity(""));
            }
        }
    }
