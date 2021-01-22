    class Cluster // possibly also IEquatable<Cluster>
    {
        public string Name { get { return name; } }
        private readonly string name;
        public Cluster(string name) { this.name = name ?? ""; }
        public override string ToString() { return Name; }
        public override int GetHashCode() { return Name.GetHashCode(); }
        public override bool Equals(object obj)
        {
            Cluster other = obj as Cluster;
            return obj == null ? false : this.Name == other.Name;
        }
    }
