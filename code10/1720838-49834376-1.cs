    public class ApplicationUser : IdentityUser, ITraits
    {
        public int Age { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public Color EyeColor { get; set; }
        public Color HairColor { get; set; }
        public int Height { get; set; }
        public Race Race { get; set; }
        public CuckRole CuckRole { get; set; }
        public BiologicalSex BiologicalSex { get; set; }
        public Sexuality Sexuality { get; set; }
        public Color SkinColor { get; set; }
        public int Weight { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Audio> Audios { get; set; }
        public bool Equals(Traits other)
        {
            throw new NotImplementedException();
        }
    }
