    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void DoesUserExist_ForValidUserId_ReturnsTrue()
        {
            var fakeUserId = 123;
            var mockUserDatabase = new Mock<IUserDatabase>();
            mockUserDatabase.Setup(udb => udb.UserExists(fakeUserId)).Returns(true);
            var userService = new UserService(mockUserDatabase.Object);
            var result = userService.DoesUserExist(fakeUserId);
            Assert.IsTrue(result);
            mockUserDatabase.VerifyAll();
        }
    }
