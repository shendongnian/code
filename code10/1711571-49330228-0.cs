    You can create fakeContext and use that.See below:
        var fakeContext = new Mock<HttpContextBase>();
        var fakeIdentity = new GenericIdentity("User");
        var principal = new GenericPrincipal(fakeIdentity, null);
        fakeContext.Setup(x => x.User).Returns(principal);
        var projectControllerContext = new Mock<ControllerContext>();
        projectControllerContext.Setup(x => 
        x.HttpContext).Returns(fakeContext.Object);  
