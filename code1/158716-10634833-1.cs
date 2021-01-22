    public sealed class HashCodeBuilder
    {
        private int hash;
        public HashCodeBuilder Add(int value)
        {
            hash = hash * 31 + value; //see Essential Java for reasoning
            return this;
        }
        public HashCodeBuilder Add(object value)
        {
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
