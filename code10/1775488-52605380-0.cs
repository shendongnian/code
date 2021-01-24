    /*assuming your movie entity has rating property of type int*/
    static void Main(string[] args)
                {
                    List<Movie> movieColletion = GetMovieCollection();
                    var top20Movies = movieCollection.OrderByDescending(m=>m.rating)>ToList().Take(20);
                }
