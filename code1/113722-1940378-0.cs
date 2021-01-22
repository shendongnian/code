    public class WCFFilter : IServiceBehavior, IDispatchMessageInspector {
		private readonly object blockLock = new object();
		private bool blockCalls = false;
		
		public bool BlockRequests {
			get {
				lock (blockLock) {
					return blockCalls;
				}
			}
			set {
				lock (blockLock) {
					blockCalls = !blockCalls;
				}	
			}
			
		}
		
		public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {			
		}
		public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) {			
		}
		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {
			foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers) {
				foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints) {
					endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
				}
			} 
		}
		public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext) {
			lock (blockLock) {
				if (blockCalls)
					request.Close();
			}
			return null;
		}
		public void BeforeSendReply(ref Message reply, object correlationState) {			
		}
	}
