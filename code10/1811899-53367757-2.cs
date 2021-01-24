    public class ApplicationUser{
        public string Id{get;set;}
        public string Name {get;set;}
        [InverseProperty("ApplicationUser")]
        public IList<HostApplicationUser> HostApplicationUsers{get;set;} 
        [InverseProperty("ApplicationCreatedUser")]
        public IList<HostApplicationUser> HostApplicationCreatedUsers{get;set;}
        [InverseProperty("ApplicationLastModifiedUser")]
        public IList<HostApplicationUser> HostApplicationLastModifiedUsers{get;set;}
        // ...
    }
