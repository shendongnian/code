    [TestMethod]
    public void Authenticate()
    {
        ////arrange
        LoginModel _LoginModel = new LoginModel("sam", "123");
        var config = InitConfiguration();
        var clientId = config["CLIENT_ID"];
        TokenController _TokenController = new TokenController(config, new UserService());
        ////act
        UserViewModel LoginnedUser = _TokenController.Authenticate(_LoginModel);
        ////assert
        Assert.IsNotNull(LoginnedUser);
    }
