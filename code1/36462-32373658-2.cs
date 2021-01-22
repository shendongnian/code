    // No need for a generated proxy class
    //using (WcfClient<IOrderService> orderService = new WcfClient<IOrderService>())
    //{
    //    results = orderService.GetProxy().PlaceOrder(input);
    //}
    public class WcfClient<TService> : ClientBase<TService>, IDisposable
        where TService : class
    {
        public WcfClient()
        {
        }
        public WcfClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }
        public WcfClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public WcfClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }
        public WcfClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }
        protected virtual void OnDispose()
        {
            bool success = false;
            if ((base.Channel as IClientChannel) != null)
            {
                try
                {
                    if ((base.Channel as IClientChannel).State != CommunicationState.Faulted)
                    {
                        (base.Channel as IClientChannel).Close();
                        success = true;
                    }
                }
                finally
                {
                    if (!success)
                    {
                        (base.Channel as IClientChannel).Abort();
                    }
                }
            }
        }
        public TService GetProxy()
        {
            return this.Channel as TService;
        }
        public void Dispose()
        {
            OnDispose();
        }
    }
