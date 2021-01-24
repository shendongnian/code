    public class Member
    {
        public string Name { get; }
    
        public string Email { get; }
    
        public int EntryYear { get; }
    
        public int MemberNumber {get; }
    
        public Member(string name, int entryYear, string email = "")
        {
            Mame = Name;
            EntryYear = entryYear;
            Email = email;
        }
    
        public Member(string name, string email = "")
        {
            Mame = Name;
            EntryYear = DateTime.Now.Year;
            Email = email;
        }
    }
