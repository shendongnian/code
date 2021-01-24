    public class GroupSetCollection {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<GroupSet> GroupSets { get; set; }
    }
