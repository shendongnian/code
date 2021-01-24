		public ActionResult Index()
		{
			var movies = GetMovies();
			return View(movies);
		}
		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie {Id = 1, Name = "Shrek"},
				new Movie {Id = 2, Name = "LotR"}
			};
		}
