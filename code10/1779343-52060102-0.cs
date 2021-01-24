    public class UniTest1
    {
        [TestMethod]
        public void LoginSuccess()
        {
            // Try to Log in
            o.Login("user", "pw");
            Assert.AreEqual(true, o.ImLoggedIn);
        }
        [TestMethod]
        public void LoginWrongPw()
        {
            // Try to Log in
            o.Login("user", "wrongpw");
            Assert.AreEqual(false, o.ImLoggedIn);
        }
        [TestMethod]
        public void LogOutSuccess()
        {
            // Login
            o.Login("user", "pw");
            // Check if steup is completed
            Assert.AreEqual(true, o.ImLoggedIn);
            bool ok = o.LogOut();
            Assert.AreEqual(true, ok);
        }
        [TestMethod, ExpectedException(NotLoggedInException)]
        public void LogOutNoLogout()
        {
            // Try to Log in
            Assert.AreEqual(false, o.ImLoggedIn);
            bool ok = o.LogOut();
        }
    }
