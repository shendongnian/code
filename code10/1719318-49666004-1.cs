    public struct AttributeKey : IEquatable<AttributeKey>
    {
        public AttributeKey(Class @class, Attribute attribute, int level)
        {
            Class = @class;
            Attribute = attribute;
            Level = level;
        }
        public readonly Class Class;
        public readonly Attribute Attribute;
        public readonly int Level;
        public bool Equals(AttributeKey other)
        {
            return Class == other.Class && Attribute == other.Attribute && Level == other.Level;
        }
        public override bool Equals(object obj)
        {
            return obj is AttributeKey && Equals((AttributeKey)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (((Class.GetHashCode() * 397) ^ Attribute.GetHashCode()) * 397) ^ Level;
            }
        }
    }
