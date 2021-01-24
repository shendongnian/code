    public void TestUserService_NotifyInactiveUsers_BeforeActivityDate()
    {
        var userRepository = new Mock<IUserRepository>();
	    var userNotification = new Mock<IUserNotification>();
	    var userService = new UserService(userRepository.Object, userNotification.Object);
	    var testUser = new User { LastActivityDate = DateTime.Now}
    	userRepository.Setup(r => r.GetAllUsers()).Returns(Enumerable.Repeat(testUser, 1));
    	userService.NotifyInactiveUsers(DateTime.Now.AddYears(-1));
	    userNotification.Verify(n => n.SendRemovalNotification(It.IsAny<User>), Times.Never);
    }
