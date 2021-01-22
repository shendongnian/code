    /// <summary>
    /// Extends ServiceHostFactory to allow ServiceHostFactory to be used.
    /// </summary>
    public class MyServiceHostFactory : ServiceHostFactory
    {
        /// <summary>
        /// Creates a new ServiceHost using the specified service and base addresses.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="baseAddresses"></param>
        /// <returns></returns>
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host;
            host = new ServiceHost(serviceType, baseAddresses);
       
            MyGlobalStaticClass.Address = baseAddresses[0]; // assuming you want the first endpoint address.
    
            return host;
        }
