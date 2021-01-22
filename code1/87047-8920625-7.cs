    public sealed class NullableWebServiceHost : ServiceHost
    {
    	public NullableWebServiceHost()
		{
		}
		public NullableWebServiceHost(object singletonInstance, params Uri[] baseAddresses) : base(singletonInstance, baseAddresses)
		{
		}
		public NullableWebServiceHost(Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
		{
		}
        protected override void OnOpening()
        {
            if (this.Description != null)
            {
                foreach (var endpoint in this.Description.Endpoints)
                {
                    if (endpoint.Binding != null)
                    {
                        var webHttpBinding = endpoint.Binding as WebHttpBinding;
                        if (webHttpBinding != null)
                        {
                            endpoint.Behaviors.Add(new NullableWebHttpBehavior());
                        }
                    }
                }
            }
            base.OnOpening();
        }
    }
