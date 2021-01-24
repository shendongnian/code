    public class UsersControllerTests
    {
        public UsersController _usersController;
        private Mock<IMYUserManager> _userManager;
        public UsersControllerTests()
        {
            _userManager = new Mock<IMYUserManager>();
            _usersController = new UsersController((new Mock<ILogger<UsersController>> 
                ()).Object, _userManager.Object);
        }
        [Fact]
        public async Task GetUser_ReturnsOkObjectResult_WhenModelStateIsValid()
        {
            //Setup
            _userManager.Setup(x => x.FindByIdAsync("realuser"))
               .Returns(Task.Run(() => new IdentityUser("realuser","realuser1")));
            _usersController.ModelState.Clear();
            //Test
            ObjectResult response = await _usersController.GetUser("realuser");
            
            //Assert
            //Should receive 200 and user data content body
            response.StatusCode.Should().Be((int)System.Net.HttpStatusCode.OK);
            response.Value.Should().NotBeNull();
        }
    }
