    [TestMethod]
    public void MyMethod_Should_Return_True() {
        //Arrange
        var mock = new Mock<IDependency>();
        mock.Setup(_ => _.SomeMethod()).Returns(It.IsAny<string>());
        var subject = new MyClass();
        var expected = true;
        
        //Act
        var actual = subject.MyMethod(mock.Object);
        
        //Assert
        Assert.AreEqual(expected, actual);
    }
