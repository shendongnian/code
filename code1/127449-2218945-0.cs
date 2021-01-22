    public class CompPoint : IEquatable<CompPoint>
    {
        // ...
        public override bool Equals(object obj)    // object
        {
            return this.Equals(obj as ComPoint);
        }
        public bool Equals(CompPoint other)    // IEquatable<ComPoint>
        {
            return !object.ReferenceEquals(other, null)
                && this.X.Equals(other.X)
                && this.Y.Equals(other.Y);
        }
        public override int GetHashCode()    // object
        {
            int hash = 5419;
            hash = (hash * 73) + this.X.GetHashCode();
            hash = (hash * 73) + this.Y.GetHashCode();
            return hash;
        }
    }
