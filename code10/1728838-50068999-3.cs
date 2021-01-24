    using AspNetCore.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;
    
    namespace XUnitTestProject1
    {
        public class HomeControllerTests
        {
            private readonly User _user;
    
            public HomeControllerTests()
            {
                _user = new User {Username = "johndoe"};
            }
    
            [Fact]
            public void OpretLobby_Test()
            {
                // Arrange
                var mockUserSession = new Mock<IUserSession>();
                mockUserSession.Setup(x => x.User).Returns(_user);
                var sut = new HomeController(mockUserSession.Object);
    
                // Act
                var result = sut.OpretLobby();
    
                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var user = Assert.IsType<User>(viewResult.Model);
                Assert.Equal(_user.Username, user.Username);
            }
        }
    }
