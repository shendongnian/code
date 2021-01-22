    // mock context variables
    var username = "user";
    var httpContext = MockRepository.GenerateMock<HttpContextBase>();
    var request = MockRepository.GenerateMock<HttpRequestBase>();
    var identity = MockRepository.GenerateMock<IIdentity>();
    var principal = MockRepository.GenerateMock<IPrincipal>();
    httpContext.Expect( c => c.Request ).Return( request ).Repeat.AtLeastOnce();
    request.Expect( r => r.IsAuthenticated ).Return( true ).Repeat.AtLeastOnce();
    httpContext.Expect( c => c.User ).Return( principal ).Repeat.AtLeastOnce();
    principal.Expect( p => p.Identity ).Return( identity ).Repeat.AtLeastOnce();
    identity.Expect( i => i.Name ).Return( username ).Repeat.AtLeastOnce();
    var controller = new MyController();
    // inject context
    controller.ControllerContext = new ControllerContext( httpContext,
                                                          new RouteData(),
                                                          controller );
    var result = controller.MyAction() as ViewResult;
    Assert.IsNotNull( result );
    
    // verify that expectations were met
    identity.VerifyAllExpectations();
    principal.VerifyAllExpectations();
    request.VerifyAllExpectations();
    httpContext.VerifyAllExpectations();
