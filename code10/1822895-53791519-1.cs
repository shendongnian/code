    public class User
    {
        public UserKey Key { get; set; }
        public UserDetails Details { get; set; }
        public string FirstName { get; set; }
    }
    public class UserKey
    {
        public Guid Id {get;set;}
    }
    public class UserDetails
    {
        public List<Guid> Domains { get; set; }
    }
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public List<Guid> DomainIds { get; set; }
    }
