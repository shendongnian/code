    public sealed class HashCodeBuilder
    {
        private int hash;
        public HashCodeBuilder Add(int value)
        {
            unchecked
            {
                hash = hash * 31 + value; //see Effective Java for reasoning
            }
            return this;
        }
        public HashCodeBuilder Add(object value)
        {
            if (value == null) return;
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
