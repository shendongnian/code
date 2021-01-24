    public static class ApplicationUtils
        {
            // this is not testable, because I dont use DI
            public static bool IsCurrentUserAManager() => TestableMethod(WindowsIdentity.GetCurrent().Name);
    
            // This is testable because it contains logics (if-else)
            public static bool TestableMethod(string username) => username == "AdminUser";
        }
    
        [TestMethod]
        public void IsCurrentUserAManagerTestIsAdmin()
        {
            Assert.IsTrue(ApplicationUtils.TestableMethod("AdminUser"));
            Assert.IsFalse(ApplicationUtils.TestableMethod("adminuser"));
        }
