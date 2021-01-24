    public class MoviesActorsViewModel
    {
        public MoviesActorsViewModel()
        {
            mvz = new Movies();
            act = new List<Actors>();
        }
    
        public Movies mvz { get; set; }
        public List<Actors> act { get; set; }
        public string[] ids { get; set; }
    }
