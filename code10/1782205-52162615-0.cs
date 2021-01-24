    public class ModelWithList {
        int Id { get; set; }
        string Name { get; set; }
        List<SetOfGroups> GroupSets { get; set; }
    }
    
    public class SetOfGroups
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
