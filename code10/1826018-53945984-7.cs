          public class ErrorHandlerBehavior : Attribute, IErrorHandler, IServiceBehavior
           {
               #region Implementation of IErrorHandler
               public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
               {
                   ServiceEndpoint endpoint =  OperationContext.Current.Host.Description.Endpoints.Find(OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri);
            DispatchOperation dispatchOperation = OperationContext.Current.EndpointDispatcher.DispatchRuntime.Operations.Where(op => op.Action == OperationContext.Current.IncomingMessageHeaders.Action).First();
            OperationDescription operationDesc = endpoint.Contract.Operations.Find(dispatchOperation.Name);
            var attributes = operationDesc.SyncMethod.GetCustomAttributes(typeof(FaultContractAttribute), true);
            if (attributes.Any())
            {
                FaultContractAttribute attribute = (FaultContractAttribute)attributes[0];
                var type = attribute.DetailType;
                object faultDetail = Activator.CreateInstance(type);
                Type faultExceptionType = typeof(FaultException<>).MakeGenericType(type);
                FaultException faultException = (FaultException)Activator.CreateInstance(faultExceptionType, faultDetail, error.Message);
                MessageFault faultMessage = faultException.CreateMessageFault();
                fault = Message.CreateMessage(version, faultMessage, faultException.Action);
            }
        }
        public bool HandleError(Exception error)
        {
            return true;
        }
        #endregion
        #region Implementation of IServiceBehavior
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                ChannelDispatcher channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    channelDispatcher.ErrorHandlers.Add(this);
                }
            }
        }
        #endregion
           }
    
