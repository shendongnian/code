    abstract class NetworkJoin
    {
        public string Name { get; set; }
    }
    class WorkgroupJoin : NetworkJoin
    {
    }
    class DomainJoin : NetworkJoin
    {
        public string Username { get; set; }
        public SecureString Password { get; set; }
    }
