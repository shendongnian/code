    //...
    var username = "some username here"
    var identity = new GenericIdentity(username, "");
    identity.AddClaim(new Claim(ClaimTypes.Name, username));
    var principal = new GenericPrincipal(identity, roles: new string[] { });
    var user = new ClaimsPrincipal(principal);
    var context = new Mock<HttpContextBase>();
    context.Setup(_ => _.User).Returns(user);
    //...
    controller.ControllerContext = new ControllerContext(context.Object, new RouteData(),  controller );
