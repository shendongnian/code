    [Fact]
    public async Task Not_Providing_Data_Should_Cause_A_Failure() {
        //Arrange
        var context = new TestableMessageHandlerContext();
    
        //Act
        Func<Task> act = () =>  _mySaga.Handle(new ImportDataReadMessage
                                    {
                                        ImportantData = null
                                    }, context);
    
        //Assert
        await Should.ThrowAsync<NoDataProvidedFailure>(act);
    }
