    public List<User> PreLoadedUserList { get; set; }
    public List<RowEntry> SomeDataRowList { get; set; }
    
    public class User
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public class RowEntry 
    {
        public int UserAge { get; set; }
        public List<User> PreLoadedUserList { get; set; }
    }
    // at the point where both PreLoadedUserList is instantiated
    // and SomeDataRowList is populated
    SomeDataRowList.ForEach(row => row.PreLoadedUserList = PreLoadedUserList);
