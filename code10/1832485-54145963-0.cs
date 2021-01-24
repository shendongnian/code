    var controller = SetupAdminTestsForPassword();
    var result = controller.ValidateTokenForUserCreation(new ValidateUserTokenRequest() { token = "VALIDCREATEUSERTOKEN"});
    var okResult = result as OkObjectResult;
    // assert
    Assert.IsNotNull(okResult);
    Assert.IsNotNull(okResult.Value);
    Assert.IsNotNull(okResult.Value as ValidateUserTokenResponse);
    Assert.IsTrue((okResult.Value as ValidateUserTokenResponse).IsValid);
