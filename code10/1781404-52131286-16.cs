    public class MoviesActorsViewModel
    {
        public MoviesActorsViewModel()
        {
            mvz = new Movies();
            act = new Actors();
        }
        public Movies mvz { get; set; }
        public Actors act { get; set; }
    }
    
