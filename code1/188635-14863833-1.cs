        public User(string userName)
        {
            this.userName = userName;
        }
        protected string userName;
        public string UserName { get { return userName; } }
    }
    public class UserUpdatable : User
    {
        public UserUpdatable()
            : base(null)
        {
        }
        public string UserName { set { userName = value; } }
    }
    
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var user = new UserUpdatable {UserName = "George"};
            Assert.AreEqual("George", (user as User).UserName);
        }
    }
