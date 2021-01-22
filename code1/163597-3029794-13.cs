    public class NeedsMovies
    {
        private readonly IMovieRepository _movies;
        public NeedsMovies(IMovieRepository movies)
        {
            _movies = movies;
        }
        public void DoStuffWithMovie(string title)
        {
            var movie = _movies.FindMovieByTitle(title);
            ...
        }
    }
