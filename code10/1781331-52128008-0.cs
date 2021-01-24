    public class Actors
    {
        public Actors()
        {
            this.Movies = new HashSet<Movies>();
        }
        public int Id { get; set; }
        public string actor_name { get; set; }
        public string country_of_birth { get; set; }
        public virtual ICollection<Movies> Movies { get; set; }
    }
    public class Movies
    {
        public Movies()
        {
            this.Actors = new HashSet<Actors>();
        }
        public int Id { get; set; }
        public string movie_title { get; set; }
        public string genre { get; set; }
        public virtual ICollection<Actors> Actors { get; set; }
    }
