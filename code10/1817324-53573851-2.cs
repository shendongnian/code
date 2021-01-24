    public static class MemberHelpers
    {
        // you would have to load this if the data is persisted in some way
        private static int _lastMemberNumber;
        public static int GetNewMemberNumber()
        {
            return _lastMemberNumber++;
        }
    }
    public Member(string name, int entryYear, string email)
    {
        Name = name;
        EntryYear = entryYear;
        Email = email;
        _memberNumber = MemberHelpers.GetNewMemberNumber();
    }
