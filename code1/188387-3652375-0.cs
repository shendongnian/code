    	public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
		{
			RemoteEndpointMessageProperty remoteAddress =
				(OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as
				 RemoteEndpointMessageProperty);
			// validate ip here
			return null;
		}
