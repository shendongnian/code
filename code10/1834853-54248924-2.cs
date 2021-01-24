     using (ChannelFactory<IService> ChannelFactory = new ChannelFactory<IService>("myservice"))
            {
                ChannelFactory.Endpoint.EndpointBehaviors.Add(new MyEndpointBehavior());
                IService service = ChannelFactory.CreateChannel();
              // call method
            
               
            }
