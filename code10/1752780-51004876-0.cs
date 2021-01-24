    namespace Artists.Models
    {
        public class Artist
        {
            public int ArtistID { get; set; }
            public string ArtistName { get; set; }
            public ICollection<Project> Projects { get; set; }
        }
    }
