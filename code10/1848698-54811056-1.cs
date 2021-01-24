    [Test]
    public void TestViaSetupVerifyAll()
    {
        //Arrange
        Mock<IDataStore> dataStore = new Mock<IDataStore>();
        dataStore
            .Setup(x => x.UpdateEmployee(It.Is<Employee>(e => e.IsEmployed == false)))
            .Verifiable();
    
        var robert = new Employee { IsEmployed = true };
    
        //Act
        FireEmployee(dataStore.Object, robert);
    
        //Assert
        dataStore.Verify();
    }
