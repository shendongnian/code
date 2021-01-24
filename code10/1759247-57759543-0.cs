    private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.NetTcpBinding_MyService))
            {
                return new System.ServiceModel.EndpointAddress(
                    new System.Uri(@"net.tcp://190.188.1.2:8201/DynamicsAx/Services/MyService"), 
                    new System.ServiceModel.UpnEndpointIdentity("host@host.com")
                    );
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
