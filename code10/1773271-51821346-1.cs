    [TestMethod]
    public async Task SomeMethod_Should_Return_False_For_Invalid_Model() {
        //Arrange
        var model = new Model() { 
            // obviously filled out with what my method accepts
        };
    
        var theService = Substitute.For<ISomeService>();
        theService
            .When(_ => _.ValidateAsync(Arg.Any<Model>()))
            .Throw(new Exception("didn't work"));
    
        var subject = new mySubjectClass(theService);
    
        var expected = false;
    
        //Act
        var actual = await subject.SomeMethod(model);
    
        //Assert
        Assert.AreEqual(expected, actual);
    }
