    public class Traductions
    {
        public string French { get; set; }
        public string English { get; set; }
    }
    
    public class CodeTraduction
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
        public CodeTraduction Groupe { get; set; }
        public CodeTraduction BusinessUnit { get; set; }
        public CodeTraduction Team { get; set; }
        public CodeTraduction Title { get; set; }
        public CodeTraduction Title2 { get; set; }
        public CodeTraduction JobCategory { get; set; }
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
        public CodeTraduction HomeBase { get; set; }
        public CodeTraduction Country { get; set; }
        public CodeTraduction State { get; set; }
        public CodeTraduction City { get; set; }
        public string ShirtSize { get; set; }
        public string LanguageAddressBook { get; set; }
        public string LanguagePrefered { get; set; }
        public string Local { get; set; }
        public string Mailbox { get; set; }
        public string HomeBusinessUnit { get; set; }
        public string JobType { get; set; }
        public string UnionCode { get; set; }
        public CodeTraduction ProfessionalTitle { get; set; }
        public bool IconEmailActif { get; set; }
        public bool IconSkypeActif { get; set; }
    }
