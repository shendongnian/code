    public class Ids
    {
        public int trakt { get; set; }
        public int tvdb { get; set; }
        public string imdb { get; set; }
        public int tmdb { get; set; }
        public int tvrage { get; set; }
    }
    
    public class Episode
    {
        public int season { get; set; }
        public int number { get; set; }
        public string title { get; set; }
        public Ids ids { get; set; }
    }
    
    public class Ids2
    {
        public int trakt { get; set; }
        public string slug { get; set; }
        public int tvdb { get; set; }
        public string imdb { get; set; }
        public int tmdb { get; set; }
        public object tvrage { get; set; }
    }
    
    public class Show
    {
        public string title { get; set; }
        public int year { get; set; }
        public Ids2 ids { get; set; }
    }
    
    public class Season
    {
        public DateTime first_aired { get; set; }
        public Episode episode { get; set; }
        public Show show { get; set; }
    }
