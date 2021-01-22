        [TestMethod]
        public void WhenUserForgetPassword_TestPropertyIsSet()
        {
            var userRepository = MockRepository.GenerateStub<IUserRepository>();
            var notificationSender = MockRepository.GenerateStub<INotificationSender>();
            userRepository.Stub(x => x.GetUserById(Arg<int>.Is.Anything)).Return(new User());
            notificationSender.TestProperty = 0;
            new LoginController(userRepository, notificationSender).ForgotMyPassword(0);
            Assert.AreEqual(notificationSender.TestProperty, 1);
        }
