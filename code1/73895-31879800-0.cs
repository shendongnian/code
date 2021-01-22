    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public async void UnitTestAnAsyncFunction()
    {
        await sut.DoStuffAsync();
    
        //Assert
        //ExpectedException
    } 
