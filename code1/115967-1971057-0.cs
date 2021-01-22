    public class Actor : Person
    {
        //Name and whatnot inherits from Person
        public List<Movie> PerformedIn
        {
            get
            {
                return myGlobalMovieList.Where(movie=>movie.Actors.Contains(this.Name));
            }
        }
    }
