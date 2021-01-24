    public class GeneralInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredFirstName { get; set; }
        public string Title { get; set; }
        public string InformalTitle { get; set; }
        public string Gender { get; set; }
        public string Discipline { get; set; }
        public string Department { get; set; }
        public string BusinessUnit { get; set; }
        public string BrandFunction { get; set; }
        public string ParentAgency { get; set; }
        public string Agency { get; set; }
        public string AgencyImagePath { get; set; }
        public string Hub { get; set; }
        public string SubRegion { get; set; }
        public string Region { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string SkypeName { get; set; }
        public string Phone { get; set; }
    }
    
    public class RootObject
    {
        public string Id { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
    }
