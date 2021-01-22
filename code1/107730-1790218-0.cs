    //code inside the setup method
     var c = new Moq.Mock<IWindsorContainer>();
     var l = new Moq.Mock<ILookupService>();
     l.Setup(o => o.GetItems(It.IsAny<String>())).Returns(new List<LookupItem>());
     c.Setup(o => o.Resolve<ILookupService>()).Returns(l.Object);
     LocatorConfigurator.SetContainer(c.Object);
