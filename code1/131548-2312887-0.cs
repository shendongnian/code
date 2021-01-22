    [Test]
    public void Save_NewName_UpdatedThingIsSavedToService()
    {
        // Arrange
        var myThing = new MyThing { 
                                    Id = 42,
                                    Name = "Thing1"
                                };
        var thingFromService = new MyThing
                        {
                            Id = 42,
                            Name = "Thing2"
                        };
    
        var thingService = new Mock<IThingService>();
        thingService
            .Setup(ts => ts.Get(myThing.Id))
            .Returns(thingFromService)
            .Verifiable();
        thingService
            .Setup(ts => ts.Save(It.Is<MyThing>(x => x.Name == myThing.Name)))
            .Verifiable();
        var myClass = new MyClass(thingService.Object);
    
        // Act
        myClass.SaveMyThing(myThing);
    
        // Assert
        thingService.Verify();
    }
