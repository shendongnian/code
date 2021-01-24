    public class MembershipSettings{
        public string DefaultProvider { get; set; }
        public Provider Provider { get; set; }
    }
    public class Provider
    {
        public string Name { get; set; }
        public string ConnectionStringName { get; set; } //not sure if it works
        public string ApplicationName { get; set; }
        //etc
    }
