    public class MoviesController : Controller
    {
        private readonly IMovieDb _movieDb;
        // Dependency Injecting access to movies
        public MoviesController(IMovieDb movieDb)
        {
            _movieDb = movieDb;
        }
  
		public ActionResult Index()
		{
			var movies = _iocDA.GetMovies();
			return View(movies);
		}
        // ....
    public interface IMovieDb
    {
        IEnumerable<Movie> GetMovies();
    }
