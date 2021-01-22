    public class Key : IEquatable<Key>
    {
        public int Index { get; private set; }
        public string Name { get; private set; }
        public Key(string keyName, int sdIndex)
        {
            this.Name = keyName;
            this.Index = sdIndex;
        }
        
	 // IEquatable implementation
        public bool Equals(Key other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;
            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;
            //Check whether the products' properties are equal.
            return Index.Equals(other.Index) && Name.Equals(other.Name);
        }
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
        public override int GetHashCode()
        {
            //Get hash code for the name field if it is not null.
            int hashKeyName = Name == null ? 0 : Name.GetHashCode();
            //Get hash code for the index field.
            int hashKeyIndex = Index.GetHashCode();
            //Calculate the hash code for the Key.
            return hashKeyName ^ hashKeyIndex;
        }
    }
