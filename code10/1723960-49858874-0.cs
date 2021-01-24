    RootObject r = JsonConvert.DeserializeObject<RootObject>(json);
    public class Traductions
    {
        public string French { get; set; }
        public string English { get; set; }
    }
    
    public class Groupe
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class BusinessUnit
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class Team
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class Title
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class JobCategory
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class HomeBase
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class Country
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class State
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class City
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class ProfessionalTitle
    {
        public string Code { get; set; }
        public Traductions Traductions { get; set; }
    }
    
    public class RootObject
    {
        public string Id { get; set; }
        public string Acronym { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Groupe Groupe { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public Team Team { get; set; }
        public Title Title { get; set; }
        public Title Title2 { get; set; }
        public JobCategory JobCategory { get; set; }
        public List<object> PhoneList { get; set; }
        public string DateHired { get; set; }
        public string DateTerminated { get; set; }
        public string Gender { get; set; }
        public string ManagerId { get; set; }
        public string ManagerAcronym { get; set; }
        public bool IsManager { get; set; }
        public string Email { get; set; }
        public string CarLicense { get; set; }
        public List<object> MyTeam { get; set; }
        public HomeBase HomeBase { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public string ShirtSize { get; set; }
        public string LanguageAddressBook { get; set; }
        public string LanguagePrefered { get; set; }
        public string Local { get; set; }
        public string Mailbox { get; set; }
        public string HomeBusinessUnit { get; set; }
        public string JobType { get; set; }
        public string UnionCode { get; set; }
        public ProfessionalTitle ProfessionalTitle { get; set; }
        public bool IconEmailActif { get; set; }
        public bool IconSkypeActif { get; set; }
    }
