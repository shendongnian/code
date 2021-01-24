    public class CommunityModel
    {
        // omitting constructor, which contains logic to 
        // initialize the Users property based on constructor arguments
        public string Name {get;set;}
        public string LoginUrl {get;set;}
        public string SiteUrl {get;set;}
        public ValidatedCollection<CommunityUserModel, string> Users
        { get; set;}
    }
    public class CommunityUserModel 
    {
        public string UserID {get; set;}
        public string VaultKeyName {get;set;}
    }
