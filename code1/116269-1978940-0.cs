    // your consuming class
    public class MyClass
    {
        private readonly RelayClientManager manager;
        
        public MyClass(RelayClientManager manager)
        {
            this.manager = manager;
        }
    
        public UserInfo GetUserInfo(int sessionID)
        {
            return manager.GetUserInfo(sessionID);
        }    
    }
    
    // 'middle-man' class
    public class RelayClientManager
    {
        public UserInfo GetUserInfo(int sessionID)
        {
            return RelayClient.GetUserInfo(sessionID);
        }
    }
    
    // unit test (using xUnit.net and Moq)
    [Fact]
    public static void GetsUserInfo()
    {
        // arrange
        var expected = new UserInfo();
        var manager = new Mock<RelayClientManager>();
        manager.Setup(x => x.GetUserInfo(0)).Returns(expected);
        var target = new MyClass(manager);        
    
        // act
        var actual = target.GetUserInfo(0);
    
        // assert
        Assert.Equal(expected, actual);
    }
