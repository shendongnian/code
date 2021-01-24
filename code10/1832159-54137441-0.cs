    public class Profile
    {
        public Guid Id { get; set; }
        public Guid? CurrentSessionId { get; set; }
        public Session CurrentSession { get; set; }
    }
    public class Session
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
    }
