    class Package 
    {
        private List<Dependency> dependencies = new List<Dependency>();
        public string Name { get; set; }
        public List<Dependency> Dependencies { get { return dependencies; } set { dependencies = value; } }
    }
    class Dependency
    {
        public string Package { get; set; }
    }
