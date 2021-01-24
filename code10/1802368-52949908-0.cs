    [TestMethod]
    public async Task eFormController_SubmitReport_MockService_ExpectHttpStatusAccepted() {
        //Arrange
        var data = "Hello World!!"
        var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data));
                
        var context = new DefaultHttpContext() {
            Request = {
                Body = stream
            }
        };
    
        var mockContextAccessor = new Mock<IHttpContextAccessor>();
        mockContextAccessor.Setup(x => x.HttpContext).Returns(context);
    
        var mockLogger = new Mock<ILogger<object>>();
        var controller = new Controllers.eFormsController();
    
        //Arrange
        var result = await controller.SubmitReport();
    
        Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.AcceptedResult));
    }
