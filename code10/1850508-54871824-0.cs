    class User : IdentityUser
    {
    	public virtual ICollection<UserMovie> UserMovieList { get; set; }
    }
    
    class UserMovie 
    {
    	public int Id { get; set; }
    	public int UserId { get; set; }
    	public int MovieId { get; set; }
    	
    	[ForeignKey("UserId")]
    	public virtual User User { get; set; }
    	
    	[ForeignKey("MovieId")]
    	public virtual Movie Movie { get; set; }
    }
    
    class Movie
    {
    	public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string UserId { get; set; }
    }
    
    var user = db.User.Include("UserMovieList").ToList();
    for (int i = 0; i < user.UserMovieList.Count; i++)
    {
    	var movie = user.UserMovieList[i].Movie;
    	// ...
    }
    
    // To get all movies of specific user
    var specificUser = db.User.Find("user id").ToList().SelectMany(a => a.Movie);
