    public sealed class HashCodeBuilder
    {
        private int hash = 17;
        public HashCodeBuilder Add(int value)
        {
            unchecked
            {
                hash = hash * 31 + value; //see Effective Java for reasoning
                 // can be any prime but hash * 31 can be opimised by VM to hash << 5 - hash
            }
            return this;
        }
        public HashCodeBuilder Add(object value)
        {
            if (value == null) return this;
            return Add(value.GetHashCode());
        }
        public HashCodeBuilder Add(float value)
        {
            return Add(value.GetHashCode());
        }
        public HashCodeBuilder Add(double value)
        {
            return Add(value.GetHashCode());
        }
        public override int GetHashCode()
        {
            return hash;
        }
    }
