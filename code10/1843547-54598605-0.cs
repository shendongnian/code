    public partial class movielist: Page
	{
		// This is list, unlike array you can insert things to it as much as you want
		private List<Movie> MoviesList = new List<Movie>();
		public movielist()
		{
			InitializeComponent();
		}
	    public void AddMovie(string newMovie)
		{
			this.MoviesList.Add(newMovie); // Adds new movie to the movies list
			String test = NewMovie.Name;
		}
	}
