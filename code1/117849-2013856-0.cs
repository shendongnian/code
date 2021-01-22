    public class MyBase<T> : IEquatable<MyBase<T>>
        where T : MyBase
    {
        public ClassName(string description) {
            Description = description;
        }
    
        public override bool Equals(object obj) { ... }
    
        public bool Equals(T other) {
            return other != null && 
                Description.Equals(other.Description);
        }
    
        public override int GetHashCode() { ... }
    
        public override string ToString() { ... }
    
        public string Description { get; private set; }
    }
