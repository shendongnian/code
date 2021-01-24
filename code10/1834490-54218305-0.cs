    public void GetFoos_AllGood_ReturnList()
    {
      //Arrange
      Mock<ISession> sessionMock = new Mock<ISession>();
    
      Web.Controllers.FooController fooController = new Web.Controllers.FooController();
      fooController.ControllerContext.HttpContext = new DefaultHttpContext();
      fooController.ControllerContext.HttpContext.Request.Headers["Foo"] = 0; 
      fooController.ControllerContext.HttpContext.Session = sessionMock.Object;
    
      //Act
      var result = fooController.GetFoos() as JsonResult;
    
      //Assert
      Assert.NotNull(result);
    }
