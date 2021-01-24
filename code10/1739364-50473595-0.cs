    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // other properties...
        public virtual ICollection<Episode> Episodes { get; set; }
    }
