    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Occupation Occupation { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public GenderEnum Gender { get; set; }
    }
