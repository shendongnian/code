    public class MovieTheaterList
    {
        // don't forget to initialize the list backing your property
        private _theaterList = new List<Theater>(); 
        public DateTime Date { get; private set; }
        public int NumTheaters { get; private set; }
        // set is unnecessary, since you'll just be adding to / removing from the list, rather than replacing it entirely
        public IList<Theater> Theaters { get { return _theaterList; } }
    }
