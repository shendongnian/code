    public class Group
    {      
        public string Name { get; set; }
        public string GroupPath { get; set; }
        public IEnumerable<VarBlock> Variables { get; }
        public IEnumerable<Group> NestedGroups { get; }
    }
