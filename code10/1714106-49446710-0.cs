    [Fact]
    public async Task Test6() {
        // Arrange
        var myClass = Substitute.ForPartsOf<MyClass>();
        myClass.MethodOne(Arg.Any<MyModel>()).Returns(Task.FromResult((object)null));
        // Act 
        await myClass.MethodTwo();
        // Assert
        //...
    }
