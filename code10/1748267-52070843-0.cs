    [TestFixture]
    public class ApiParserControllerTests
    {
        private ApplicationDbContext _dbContext;
    
        [SetUp]
        public void SetUp(){
            // initialize here
           _dbContext = new ApplicationDbContext();
        }
        [Test]
        public void IsOptionValid_Teacher_ShouldReturnTrue()
        {
            var model = new ApiParserController(_dbContext);
            var assign = model.IsOptionValid("Teacher");
            Assert.AreEqual(true, assign.Value);
        }
    }
