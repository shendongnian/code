    BindingElement[] elements = new BindingElement[]
            {
            
                           new TextMessageEncodingBindingElement(),
              new HttpTransportBindingElement()
            };
            CustomBinding binding = new CustomBinding(elements);
                        using (ChannelFactory<ICalculatorService> channelFacoty = new ChannelFactory<ICalculatorService>(binding, new EndpointAddress("http://localhost:4000/calculator")))
            {
                ICalculatorService cal = channelFacoty.CreateChannel();
               Console.WriteLine( cal.Add(1, 3));
                Console.Read();
            }
