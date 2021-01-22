    [Test]
    public void TestForOutParameterInMoq()
    {
      //Arrange
      _mockParameterManager= new Mock<IParameterManager>();
      Mock<IParameter > mockParameter= new Mock<IParameter >();
      //Parameter affectation should be useless but is not. It's really used by Moq 
      IParameter parameter= mockParameter.Object;
      //Mock method used in UpperParameterManager
      _mockParameterManager.Setup(x => x.OutMethod(out parameter));
      //Act with the real instance
      _UpperParameterManager.UpperOutMethod(out parameter);
      //Assert that method used on the out parameter of inner out method are really called
      mockParameter.Verify(x => x.FunctionCalledInOutMethodAfterInnerOutMethod(),Times.Once());
      
    }
