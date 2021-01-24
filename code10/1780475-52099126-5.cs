    [Fact]
    public async Task LoginTest_Post_UserHasInValidCredentials() {
        // Arrange
        var mockModel = new LoginViewModel { };
        mockModel.Password = "TestPassword";
        mockModel.Email = "test@test.com";
        mockModel.RememberMe = false;
        var commonResult = new CommonResult {
            Object = null,
            Succeeded = false,
            StatusCode = Common.Enums.ResponseStatusCodeEnum.Success
        };
        var mockWebService = new Mock<IWebService>();
        var accountController = new AccountController(mockWebService.Object) {
            //HttpContext would also be needed
        };
        mockWebService
            .Setup(test => test.PostRequestAsync<CommonResult>(Constants.UserLoginAPI, mockModel))
            .ReturnsAsync(commonResult);
        //
        //Act
        var result = await accountController.Login(mockModel);
        //Assert
        //...Make assertions here
    }
