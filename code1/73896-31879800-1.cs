    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public async Task UnitTestAnAsyncFunction()
    {
        await sut.DoStuffAsync();
    
        //Assert
        //ExpectedException
    } 
