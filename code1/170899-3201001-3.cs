    public class ChannelFactoryManager : IDisposable
    {
        private static Dictionary<Type, ChannelFactory> _factories = new Dictionary<Type,ChannelFactory>();
        private static readonly object _syncRoot = new object();
        public virtual T CreateChannel<T>() where T : class
        {
            return CreateChannel<T>("*", null);
        }
    
        public virtual T CreateChannel<T>(string endpointConfigurationName) where T : class
        {
            return CreateChannel<T>(endpointConfigurationName, null);
        }
    
        public virtual T CreateChannel<T>(string endpointConfigurationName, string endpointAddress) where T : class
        {
            T local = GetFactory<T>(endpointConfigurationName, endpointAddress).CreateChannel();
            ((IClientChannel)local).Faulted += ChannelFaulted;
            return local;
        }
    
        protected virtual ChannelFactory<T> GetFactory<T>(string endpointConfigurationName, string endpointAddress) where T : class
        {
            lock (_syncRoot)
            {
                ChannelFactory factory;
                if (!_factories.TryGetValue(typeof(T), out factory))
                {
                    factory = CreateFactoryInstance<T>(endpointConfigurationName, endpointAddress);
                    _factories.Add(typeof(T), factory);
                }
                return (factory as ChannelFactory<T>);
            }
        }
    
        private ChannelFactory CreateFactoryInstance<T>(string endpointConfigurationName, string endpointAddress)
        {
            ChannelFactory factory = null;
            if (!string.IsNullOrEmpty(endpointAddress))
            {
                factory = new ChannelFactory<T>(endpointConfigurationName, new EndpointAddress(endpointAddress));
            }
            else
            {
                factory = new ChannelFactory<T>(endpointConfigurationName);
            }
            factory.Faulted += FactoryFaulted;
            factory.Open();
            return factory;
        }
    
        private void ChannelFaulted(object sender, EventArgs e)
        {
            IClientChannel channel = (IClientChannel)sender;
            try
            {
                channel.Close();
            }
            catch
            {
                channel.Abort();
            }
            throw new ApplicationException("Exc_ChannelFailure");
        }
    
        private void FactoryFaulted(object sender, EventArgs args)
        {
            ChannelFactory factory = (ChannelFactory)sender;
            try
            {
                factory.Close();
            }
            catch
            {
                factory.Abort();
            }
            Type[] genericArguments = factory.GetType().GetGenericArguments();
            if ((genericArguments != null) && (genericArguments.Length == 1))
            {
                Type key = genericArguments[0];
                if (_factories.ContainsKey(key))
                {
                    _factories.Remove(key);
                }
            }
            throw new ApplicationException("Exc_ChannelFactoryFailure");
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (_syncRoot)
                {
                    foreach (Type type in _factories.Keys)
                    {
                        ChannelFactory factory = _factories[type];
                        try
                        {
                            factory.Close();
                            continue;
                        }
                        catch
                        {
                            factory.Abort();
                            continue;
                        }
                    }
                    _factories.Clear();
                }
            }
        }
    }
