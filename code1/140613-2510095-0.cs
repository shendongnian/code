    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> Reflect();
        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as T);
        }
        public bool Equals(T other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Reflect().SequenceEqual(other.Reflect());
        }
        public override int GetHashCode()
        {
            return Reflect().Aggregate(36, (hashCode, value) => value == null ?
                                    hashCode : hashCode ^ value.GetHashCode());
        }
        public override string ToString()
        {
            return "{ " + Reflect().Aggregate((l, r) => l + ", " + r) + " }";
        }
    }
