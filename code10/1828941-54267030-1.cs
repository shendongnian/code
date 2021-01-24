    [Test]
    public void Test()
    {
        var mockClass1 = new Mock<IClass1>();
        mockClass1.Setup(x => x.VerifyPrecondition(It.IsAny<string>())).Returns("test");
        var dataClass = new DataClass(mockClass1.Object);
        
        dataClass.ExecuteCondition();
        //Assert
    }
