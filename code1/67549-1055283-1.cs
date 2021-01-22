    [TestFixture]
    public class AuthHelperTests {
        Mock<MembershipProvider> memberShipProvider;
        Mock<MembershipUser> user;
        [SetUp]
        public void Init() {
            memberShipProvider = new Mock<MembershipProvider>();
            user = new Mock<MembershipUser>();
            user.SetupGet(u => u.Email)
                .Returns("test@test.com");
            user.Setup(u => u.ResetPassword("secret"))
                .Returns("test2");
            memberShipProvider
                .Setup(prov => prov.GetUser("test", false))
                .Returns(user.Object);
        }
        [Test]
        public void WillResetPasswordByCallingProvider() {
            var helper = new AuthenticationHelper(memberShipProvider.Object);
            string newPassword = helper.PasswordRecoveryStep2("test", "secret");
            Assert.AreEqual("test2", newPassword);
            memberShipProvider.Verify(p => p.GetUser("test", false));
            user.Verify(u => u.ResetPassword("secret"));
        }
    }
