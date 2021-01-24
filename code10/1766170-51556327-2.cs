    class Group {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<Group> Members { get; set; }
        public Group() {
            Members = new List<Group>();
        }
    }
