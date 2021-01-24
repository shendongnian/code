	public IServiceProvider createServiceProviderMock() {
		var authServiceMock = new Mock<IAuthenticationService>();
		authServiceMock
			.Setup(_ => _.SignInAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
			.Returns(Task.FromResult((object)null)); //<-- to allow async call to continue
		var serviceProviderMock = new Mock<IServiceProvider>();
		serviceProviderMock
			.Setup(_ => _.GetService(typeof(IAuthenticationService)))
			.Returns(authServiceMock.Object);
			
		return serviceProviderMock.Object;
	}
	
