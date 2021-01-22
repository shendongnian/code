    class SomeEntityRepository: IRepository<SomeEntity>
    {
        public SomeEntityRepository(IDataContext context)
        {
            m_context = context;
        }
    
        private readonly IDataContext m_context;
    
        public SomeEntity GetById(long id)
        {
            // implementation
        }
    }
    // xUnit.NET & Moq
    class SomeEntityRepositoryTests
    {
        [Fact]
        public void GetById_returns_entity_when_valid_id_is_passed()
        {
            // state and context
            var mockContext = new Mock<IDataContext>();
            // arrangement
            mockContext.Setup(/* configure mock context here */);
            var repo = new SomeEntityRepository(mockContext.Object);
            
            // activity
            var entity = repo.GetById(100);
            // assertions
        }
    }
