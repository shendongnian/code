    namespace MyProject.Tests.Repositories.SqlServer
    {
        // ReSharper disable InconsistentNaming
    
        [TestClass]
        public class UserRepositoryTests : TestBase
        {
            [ClassInitialize]
            public static void ClassInitialize(TestContext testContext)
            {
                // Arrange.
                // NOTE: this method is inherited from the TestBase abstract class.
                // Eg. protected IUserRepository = 
                //     new MyProject.Respositories.SqlServer
                //         .UserRespository(connectionString);
                InitializeSqlServerTestData();
            }
    
            [TestMethod]
            public void GetFirst20UsersSuccess()
            {
                // Act.
                var users = _users.GetUsers()
                    .Take(20)
                    .ToList();
    
                // Assert.
                Assert.IsNotNull(users);
                Assert.IsTrue(users.Count() > 0);
            }
        }
    }
