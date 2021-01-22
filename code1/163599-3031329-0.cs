    // Data Contract (or Data Transfer Object)
    public class Movie
    {
            public Image Poster { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Rating { get; set; }
            public string Director { get; set; }
            public List<string> Writers { get; set; }
            public List<string> Genres { get; set; }
            public string Tagline { get; set; }
            public string Plot { get; set; }
            public List<string> Cast { get; set; }
            public string Runtime { get; set; }
            public string Country { get; set; }
            public string Language { get; set; }
    }
    // Movie database searching service contract
    public interface IMovieSearchService    
    {
            Movie FindMovie(string Title);
            Movie FindKnownMovie(string ID);
    }
    // Movie database searching service
    public partial class MovieSearchService: IMovieSearchService
    {
            public Movie FindMovie(string Title)
            {
                Movie film = new Movie();
                Parser parser = Parser.FromMovieTitle(Title);
    
                film.Poster = parser.Poster();
                film.Title = parser.Title();
                film.ReleaseDate = parser.ReleaseDate();
                //And so an so forth.
            }
    
            public Movie FindKnownMovie(string ID)
            {
                Movie film = new Movie();
                Parser parser = Parser.FromMovieID(ID);
    
                film.Poster = parser.Poster();
                film.Title = parser.Title();
                film.ReleaseDate = parser.ReleaseDate();
                //And so an so forth.
            }
    }
