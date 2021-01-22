    public sealed class NullableWebServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			return new NullableWebServiceHost(serviceType, baseAddresses);
		}
	}
