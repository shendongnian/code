    public class PersonA
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<RoleB> Roles { get; set; }       
    }
    public class RoleB : RoleA
    {
        public string town { get; set; }
    }
    public class PersonB
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<RoleA> RolesA { get; set; } = new List<RoleA>();
        public List<RoleB> RolesB { get; set; } = new List<RoleB>();
    }
    public class RoleA
    {
        public string name { get; set; }
        public string type { get; set; }
    }
