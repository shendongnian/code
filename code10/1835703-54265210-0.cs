    public class MovieSeedDataFixture : IDisposable
    {
        public MovieDbContext MovieContext { get; private set; }
        public MovieSeedDataFixture()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                .UseInMemoryDatabase("MovieListDatabase")
                .Options;
            MovieContext = new MovieDbContext(options);
            MovieContext.Movies.Add(new Movie { Id = 1, Title = "Movie 1", YearOfRelease = 2018, Genre = "Action" });
            MovieContext.Movies.Add(new Movie { Id = 2, Title = "Movie 2", YearOfRelease = 2018, Genre = "Action" });
            MovieContext.Movies.Add(new Movie { Id = 3, Title = "Movie 3", YearOfRelease = 2019, Genre = "Action" });
            MovieContext.SaveChanges();
        }
        public void Dispose()
        {
            MovieContext.Dispose();
        }
    }
