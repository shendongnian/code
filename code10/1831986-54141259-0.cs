      WSHttpBinding wsbinding = new WSHttpBinding();
            wsbinding.MaxBufferPoolSize = 2147483647;
            wsbinding.MaxReceivedMessageSize = 2147483647;
            wsbinding.MessageEncoding = WSMessageEncoding.Mtom;
            wsbinding.TextEncoding = Encoding.UTF8;
            wsbinding.Security.Mode = SecurityMode.Transport;
            wsbinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            using (ChannelFactory<ICalculatorService> channelFacoty = new ChannelFactory<ICalculatorService>(wsbinding, new EndpointAddress("http://localhost")))
            {
                ICalculatorService cal = channelFacoty.CreateChannel();
               Console.WriteLine( cal.Add(1, 3));
                Console.Read();
            }
