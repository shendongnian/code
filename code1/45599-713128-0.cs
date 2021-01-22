     public interface IUser
        {
           
            // Base class public properties
            string UserName { get; }
            object ProviderUserKey { get; }
            string Email { get; set; }
            string PasswordQuestion { get; }
            string Comment { get; set; }
            bool IsApproved { get; set; }
            bool IsLockedOut { get; }
            DateTime LastLockoutDate { get; }
            DateTime CreationDate { get; }
            DateTime LastLoginDate { get; set; }
            DateTime LastActivityDate { get; set; }
            DateTime LastPasswordChangedDate { get; }
            bool IsOnline { get; }
            string ProviderName { get; }
            string ToString();
            string GetPassword();
            string GetPassword(string passwordAnswer);
            bool ChangePassword(string oldPassword, string newPassword);
            bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer);
            string ResetPassword(string passwordAnswer);
            string ResetPassword();
            bool UnlockUser();
        }
        public class Caller
        {
            public Caller(IUser newUser)
            {
                user = newUser;
            }
            public IUser user { get; private set; }
        }
        [Test]
        public void RhinoTest()
        {
            var userId = Guid.NewGuid();
            var mocks = new MockRepository();
            var mockUser = mocks.StrictMock<IUser>();
            var caller = new Caller(mockUser);
            Expect.Call(mockUser.ProviderUserKey).Return(userId);
            
            mocks.ReplayAll();
            var userFromCaller = caller.user.ProviderUserKey;
            Assert.AreEqual(userId, userFromCaller, "Incorrect userId");
            mockUser.VerifyAllExpectations();
        }
        [Test]
        public void AnotherRhinoTest()
        {
            var userId = Guid.NewGuid();
            var mockUser = MockRepository.GenerateMock<IUser>();
            var caller = new Caller(mockUser);
            mockUser.Expect(m=>m.ProviderUserKey).Return(userId);
            var userFromCaller = caller.user.ProviderUserKey;
            Assert.AreEqual(userId, userFromCaller, "Incorrect userId");
            mockUser.VerifyAllExpectations();
        }
