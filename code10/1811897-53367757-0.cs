    public class ApplicationUser{
        public string Id{get;set;}
        public string Name {get;set;}
        public IList<HostApplicationUser> HostApplicationUsers{get;set;} 
    }
