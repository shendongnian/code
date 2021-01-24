    [Test]
    public void TestCreateCars()
    {
        // Arrange
        var expectedCars = new List<Car>();
        expectedCars.Add(TestUtils.CreateObject<Car>(1));
        expectedCars.Add(TestUtils.CreateObject<Car>(2));
        expectedCars.Add(TestUtils.CreateObject<Car>(3));
    
        // using moq but anything could be used
        _carService.Setup(x => x.GetNewCarsInfo()).Returns(cars);
    
        var carsFactory = new carFactory(_carService);
    
        // Act
        var cars = carsFactory.CreateCars();
    
        // Assert
        Assert.AreEqual(3, cars.Count);
        TestUtils.AssertObjectDefaultFields(cars[0], 1);
        TestUtils.AssertObjectDefaultFields(cars[1], 2);
        TestUtils.AssertObjectDefaultFields(cars[2], 3);
    
        _carService.VerifyAll();
    }
