    [TestMethod]
    public async Task eFormController_SubmitReport_MockService_ExpectHttpStatusAccepted() {
        //Arrange
        var data = "Hello World!!"
        var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data));
                
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Body = stream;
       
        var mockLogger = new Mock<ILogger<object>>();
        
        var controllerContext = new ControllerContext() {
            HttpContext = httpContext,
        };
        var controller = new Controllers.eFormsController(mockLogger.Object) {
             ControllerContext = controllerContext,
        };
    
        //Arrange
        var result = await controller.SubmitReport();
    
        //Assert
        Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.AcceptedResult));
    }
