    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name) : base(name){}
    
        public string Description { get; set; }
    }
