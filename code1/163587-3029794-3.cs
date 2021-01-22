    public class Movie
    {
        private static readonly IMovieRepository _defaultRepository =
            new MovieRepository(new HtmlDownloader());
        public static Movie FindMovieById(string id)
        {
            return _defaultRepository.FindMovieById(id);
        }
        public static Movie FindMovieByTitle(string title)
        {
            return _defaultRepository.FindMovieByTitle(title);
        }
        // ...
    }
