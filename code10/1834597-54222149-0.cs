    IDeliveryContext deliveryContext = // ???? - whatever you want it to be. 
                                       // Could be another Mock.
                                       // This is what the Mock will return.
    Mock<IDeliveryStrategy> deliveryStrategy = new Mock<IDeliveryStrategy>();
    deliveryStrategy.Setup(x => x.GetDeliveryCodeStrategy(It.IsAny<decimal>()))
        .Returns(deliveryContext);
    
