	[TestFixture]
	public class AgentRepositoryTest {
		private AgentRepository m_repo;
		private Mock<IAgentDataProvider> m_mockProvider;
		[SetUp]
		public void CaseSetup() {
			m_mockProvider = new Mock<IAgentDataProvider>();
			m_repo = new AgentRepository( m_mockProvider.Object );
		}
		[TearDown]
		public void CaseTeardown() {
			m_mockProvider.Verify();
		}
		[Test]
		public void AgentFactory_OnEmptyDataReader_ShouldReturnNull() {
			m_mockProvider
				.Setup( p => p.GetAgent( It.IsAny<int>() ) )
				.Returns<int>( id => GetEmptyAgentDataReader() );
			Agent agent = m_repo.GetAgent( 1 );
			Assert.IsNull( agent );
		}
		[Test]
		public void AgentFactory_OnNonemptyDataReader_ShouldReturnAgent_WithFieldsPopulated() {
			m_mockProvider
				.Setup( p => p.GetAgent( It.IsAny<int>() ) )
				.Returns<int>( id => GetSampleNonEmptyAgentDataReader() );
			Agent agent = m_repo.GetAgent( 1 );
			Assert.IsNotNull( agent );
                        // verify more agent properties later
		}
		private IDataReader GetEmptyAgentDataReader() {
			return new FakeAgentDataReader() { ... };
		}
		private IDataReader GetSampleNonEmptyAgentDataReader() {
			return new FakeAgentDataReader() { ... };
		}
	}
