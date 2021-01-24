    var context = new Mock<HttpContextBase>(); 
    var identity = new GenericIdentity("testuser");
    identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
    var principal = new GenericPrincipal(identity, new[] { "user" } );
    context.Setup(s => s.User).Returns(principal);
    ApiController controller = new ApiController();
    controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
