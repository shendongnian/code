       for(int i = 0; i < 10; i++) 
       { 
            ChannelFactory<WebServiceClient.IService> factory = 
               new ChannelFactory<WebServiceClient.IService>(
                   binding, 
                   new EndpointAddress("http://localhost/WebService/Service")); 
     
            WebServiceClient.IService service = factory.CreateChannel(); 
            using(service as IDsposable)
            {
              using(MemoryStream s = service.Result() as MemoryStream)
              {
                 // write this stream to a file
              }
            }
       } 
 
