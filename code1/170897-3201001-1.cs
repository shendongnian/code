    public class WCFServiceInvoker : IServiceInvoker
    {
        private static ChannelFactoryManager _factoryManager = new ChannelFactoryManager();
        private static ClientSection _clientSection = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;
    
        public R InvokeService<T, R>(Func<T, R> invokeHandler) where T : class
        {
            var endpointNameAddressPair = GetEndpointNameAddressPair(typeof(T));
            T arg = _factoryManager.CreateChannel<T>(endpointNameAddressPair.Key, endpointNameAddressPair.Value);
            ICommunicationObject obj2 = (ICommunicationObject)arg;
            try
            {
                return invokeHandler(arg);
            }
            finally
            {
                try
                {
                    if (obj2.State != CommunicationState.Faulted)
                    {
                        obj2.Close();
                    }
                }
                catch
                {
                    obj2.Abort();
                }
            }
        }
    
        private KeyValuePair<string, string> GetEndpointNameAddressPair(Type serviceContractType)
        {
            var configException = new ConfigurationErrorsException(string.Format("No client endpoint found for type {0}. Please add the section <client><endpoint name=\"myservice\" address=\"http://address/\" binding=\"basicHttpBinding\" contract=\"{0}\"/></client> in the config file.", serviceContractType));
            if (((_clientSection == null) || (_clientSection.Endpoints == null)) || (_clientSection.Endpoints.Count < 1))
            {
                throw configException;
            }
            foreach (ChannelEndpointElement element in _clientSection.Endpoints)
            {
                if (element.Contract == serviceContractType.ToString())
                {
                    return new KeyValuePair<string, string>(element.Name, element.Address.Host);
                }
            }
            throw configException;
        }
    }
