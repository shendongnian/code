    public class Group : IGroup {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ParentID { get; set; }
        public IList<IGroup> Groups { get; set; }
        public Group() {
            Groups = new List<IGroup>();
        }
    }
