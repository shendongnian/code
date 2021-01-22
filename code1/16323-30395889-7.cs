    public abstract class EquatableBase<T>
        where T : class 
    {
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            T other = obj as T;
            if (other == null)
            {
                return false;
            }
            return Equals(other);
        }
        protected abstract bool Equals(T other);
        public override int GetHashCode()
        {
            unchecked
            {
                return ComputeHashCode();
            }
        }
        protected abstract int ComputeHashCode();
    }
