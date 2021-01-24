    public abstract class Role
    {
        public string lala { get; set; }
        public string abab { get; set; }
        public string cxcx { get; set; }
        public Role(string lala, string abab, string cxcx)
        {
        }
        public abstract List<Role> GetMembers();
    }
