        [TestClass]
    public class GigRepositoryTests
    {
        private GigRepository _repository;
        private Mock<DbSet<Gig>> _mockGigs;
        private Mock<IApplicationDbContext> mockContext;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockGigs = new Mock<DbSet<Gig>>();
            mockContext = new Mock<IApplicationDbContext>();
            _repository = new GigRepository(mockContext.Object);
        }
        [TestMethod]
        public void GetUpcomingGigsByArtist_GigsInThePast_ShouldNotBeReturned()
        {
            var gig = new Gig() {DateTime = DateTime.Now.AddDays(-1), ArtistId = "1"};
            _mockGigs.SetSource(new List<Gig> {gig});
            mockContext.SetupGet(c => c.Gigs).Returns(_mockGigs.Object);
            var gigs = _repository.GetUpcomingGigs("1");
            gigs.Should().BeEmpty();
        } }
