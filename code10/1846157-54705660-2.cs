    using (ChannelFactory<ICotractWithoutAttribute> factory = new ChannelFactory<ICotractWithoutAttribute>("without"))
            {
                ICotractWithoutAttribute cotractWithoutAttribute = factory.CreateChannel();
                ServiceInterface.Models.MyDataFather myDataFather = cotractWithoutAttribute.GetData(new ServiceInterface.Models.MyDataFather { MyData = new ServiceInterface.Models.MyData { Name = "MICK", Age = 18, Id = 1 } });
            }
