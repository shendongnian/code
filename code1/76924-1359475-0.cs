    public class TreeViewEntry
    {
        public string Name { get; set; }
        public IEnumerable<TreeViewEntry> Children { get; set; }
        public object Model { get; set; }
    }
