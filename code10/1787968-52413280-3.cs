        [TestMethod]
        public void InsertUser_Returns_UserWM_On_Successful_Request()
        {
            UserManager userManager = new UserManager();
            MD5Hasher passwordHasher = new MD5Hasher();
            Random rnd = new Random();
            int dummyEmailName = rnd.Next(0, 700);
            string dummyEmail = dummyEmailName.ToString() + "@gmail.com";
            UserActivationRequest userActivationRequest = new UserActivationRequest
            {
                EMail = dummyEmail,
                ActivationCode = "444855",
                IsUsed = false,
                IsActive = true,
                ConfirmationType = 1,
                ReadCount = 0
            };
            UserCreateAccountWM userCreateAccountWM = new UserCreateAccountWM()
            {
                FirstName = "Unit",
                LastName = "Test",
                Email = dummyEmail,
                Password = passwordHasher.Encrypt("yC123456?"),
                CountryID = 1,
                PhoneCountryCode = 90,
                MobileNumber = "5327894512",
                ActivationCode = "444855"
            };
            var validationMock = new Mock<UserManager>();
            validationMock.CallBase = true;
            validationMock.Setup(x => x.InsertUserValidation(It.IsAny<UserCreateAccountWM>())).Returns(userActivationRequest);
            var testResult = validationMock.Object.InsertUser(userCreateAccountWM);
            Assert.AreEqual(typeof(UserWM), testResult.GetType());
        }
