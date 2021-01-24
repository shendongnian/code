    [Test]
    public void MoqCallTests()
    {
        // Arrange
        var _mock = new Mock<IRepo>();
        // you setup call
        _mock.Setup(x => x.Method(It.IsAny<Model>(), It.IsAny<string>(), It.IsAny<int>()));
        var service = new Service(_mock.Object);
        // Act 
        // call method with 'rubbish'
        service.GetResults(new Model {IsPresent = true, Search = "rubbish"}, string.Empty, 0);
        // call method with 'term'
        service.GetResults(new Model {IsPresent = true, Search = "term" }, string.Empty, 0);
        // Assert
        // your varify call
        _mock.Verify(x => x.Method(It.Is<Model>(p => p.IsPresent && p.Search.Equals("term")), It.IsAny<string>(), It.IsAny<int>()), Times.Once());
    }
    public class Service
    {
        private readonly IRepo _repo;
        public Service(IRepo repo)
        {
            _repo = repo;
        }
        // your method for tests
        public Results GetResults(Model model, string s, int i)
        {
            return _repo.Method(model, s, i);
        }
    }
    public interface IRepo
    {
        Results Method(Model model, string s, int i);
    }
    public class Model
    {
        public bool IsPresent { get; set; }
        public string Search { get; set; }
    }
    public class Results
    {
    }
