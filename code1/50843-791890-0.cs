    [TestFixture]
    public class ServiceClassTester
    {
        private ServiceClass _service;
        private IRepository _repository;
        private IQueryable<ActionType> _actionQuery;
        [SetUp]
        public void SetUp()
        {
            _service = new ServiceClass(_repository);
            // set up the actions. There is probably a more elegant way than this.
            _actionQuery = (new List<ActionType>() { ActionA, ActionB }).AsQueryable();
            // setup the repository
            _repository = MockRepository.GenerateMock<IRepository>();
            _repository.Stub(x => x.Query<ActionType>()).Return(_actionQuery);
        }
    
        [Test]
        public void heres_a_test()
        {
            // act
            var actions = _service.GetAvailableActions();
    
            // assert
            Assert.AreEqual(1, actions.Count());
            // more asserts on he result of the tested method
        }
    
    }
