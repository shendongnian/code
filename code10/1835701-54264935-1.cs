    public class UnitTests : IClassFixture<MovieSeedDataFixture>
    {
        MovieSeedDataFixture fixture;
        public UnitTests(MovieSeedDataFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void TestOne()
        {
            // use fixture.MovieContext in your tests
        }
    }
