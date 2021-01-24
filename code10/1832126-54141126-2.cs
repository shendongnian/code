     using (ChannelFactory<ICalculatorService> channelFacoty = new ChannelFactory<ICalculatorService>("cal"))
            {
                ICalculatorService cal = channelFacoty.CreateChannel();
               Console.WriteLine( cal.Add(1, 3));
                Console.Read();
            }
