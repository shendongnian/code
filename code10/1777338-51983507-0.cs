    public class MyObject : IEquatable<MyObject>
    {
        public string Name { get; set; }
        public IEnumerable<MyObjectChild> MyObjectChilds { get; set; }
        public bool Equals<MyObject>(MyObject other) { return this.Name.Equals(other.Name);    }
    }
