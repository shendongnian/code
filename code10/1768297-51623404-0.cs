    public void Signup_Fail_DuplicateEmail_Controller_Test() {
        //Arrange
        var user = UserHelper.CreateSignupUser();
        user.Email = "duplicate@test.com";
        var uRepo = new Mock<IUserRepository>();
    
        uRepo
            .Setup(_ => _.GetSingle(It.IsAny<Expression<Func<T, bool>>>()))
            .Returns(user);
    
        var uc = new UserController(uRepo.Object);
    
        //Act
        var result = uc.Signup(user);
    
        //Assert
        var status = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(StatusCodes.Status409Conflict, status.StatusCode);
    }
