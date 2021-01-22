    [Test]
    public void WhenUserForgetPasswordWillSendNotification_UsingExpect()
    {
        var userRepository = MockRepository.GenerateStub<IUserRepository>();
        var notificationSender = MockRepository.GenerateMock<INotificationSender>();
    
        userRepository.Stub(x => x.GetUserById(5)).Return(new User { Id = 5, Name = "ayende" });
        notificationSender.Expect(x => x.Send(null)).Constraints(Text.StartsWith("Changed"));
    
        new LoginController(userRepository, notificationSender).ForgotMyPassword(5);
    
        notificationSender.VerifyAllExpectations();
    }
