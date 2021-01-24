    public class Member
    {
        public string Name { get; }
        public string Email { get; set; }
        public int EntryYear { get; set; }
        private int _memberNumber;
        public Member(string name) : this(name, DateTime.Now.Year, "")
        { }
        public Member(string name, int year) : this(name, year, "")
        { }
        public Member(string name, string email) : this(name, DateTime.Now.Year, email)
        { }
        public Member(string name, int entryYear, string email)
        {
            Name = name;
            EntryYear = entryYear;
            Email = email;
        }
    }
