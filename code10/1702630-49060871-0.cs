    var authenticationServiceMock = new Mock<IAuthenticationService>();
    authenticationServiceMock
        .Setup(a => a.SignInAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
        .Returns(Task.CompletedTask);
    var serviceProviderMock = new Mock<IServiceProvider>();
    serviceProviderMock
        .Setup(s => s.GetService(typeof(IAuthenticationService)))
        .Returns(authenticationServiceMock.Object);
