    public class ParserFactory
    {
        public virtual Parser GetParser(string criteriaType)
        {
            if (criteriaType == "bytitle") return new ByTitleParser();
            else if (criteriaType == "byid") return new ByIdParser();
            else throw new ArgumentException("Unknown criteria type.", "criteriaType");
        }
    }
    // Improved movie database search service
    public class MovieSearchService: IMovieSearchService
    {
            public MovieSearchService(ParserFactory parserFactory)
            {
                m_parserFactory = parserFactory;
            }
            private readonly ParserFactory m_parserFactory;
            public Movie FindMovie(string Title)
            {
                var parser = m_parserFactory.GetParser("bytitle");
                var movies = parser.Parse(Title); // Parse method creates an enumerable set of Movies that matched "Title"
                var firstMatchingMovie = movies.FirstOrDefault();
                return firstMatchingMovie;
            }
    
            public Movie FindKnownMovie(string ID)
            {
                var parser = m_parserFactory.GetParser("byid");
                var movies = parser.Parse(Title); // Parse method creates an enumerable set of Movies that matched "ID"
                var firstMatchingMovie = movies.FirstOrDefault();
                return firstMatchingMovie;
            }
    }
