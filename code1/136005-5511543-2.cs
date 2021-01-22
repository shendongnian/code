    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    
    namespace NewWcfService
    {
            public class SelfDescribingServiceHostFactory : ServiceHostFactory
        {
            protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
            {
                //All the custom factory does is return a new instance
                //of our custom host class. The bulk of the custom logic should
                //live in the custom host (as opposed to the factory) for maximum
                //reuse value.
                return new SelfDescribingServiceHost(serviceType, baseAddresses);
            }
        }
    }
