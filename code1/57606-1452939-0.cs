        public class IdtUser : IIdtUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        ...
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }
    }
