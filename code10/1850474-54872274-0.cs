    var identityMock = new Mock<IIdentity>();
    identityMock.SetupGet(x => x.Name).Returns("UsernameWithoutDomain");
    HttpContext.Current =
        new HttpContext(new HttpRequest(null, "http://test.com", null), new HttpResponse(null))
        {
            User = new GenericPrincipal(identityMock.Object, new[] {"Role1"})
        };
    var myController = new AccountController();
