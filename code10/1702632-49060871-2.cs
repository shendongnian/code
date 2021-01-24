    // mock setup, as above
    // …
    // arrange
    var controller = new AuthController(repositoryMock.Object);
    controller.ControllerContext = new ControllerContext
    {
        HttpContext = new DefaultHttpContext()
        {
            RequestServices = serviceProviderMock.Object
        }
    };
    var registrationVm = new RegistrationViewModel();
    // act
    var result = await controller.Registration(registrationVm);
    // assert
    var redirectResult = result as RedirectToActionResult;
    Assert.NotNull(redirectResult);
    Assert.Equal("Welcome", redirectResult.ActionName);
