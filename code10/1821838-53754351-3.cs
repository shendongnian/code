    public abstract class MyEquatable<T> : IEquatable<T>
        where T : MyEquatable<T>
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return this.Equals((MyEquatable<T>)obj);
        }
        protected bool Equals(MyEquatable<T> other)
        {
            return this.Equals(other as T);
        }
        public static bool operator ==(MyEquatable<T> lhs, object rhs)
        {
            return Equals(lhs, rhs);
        }
        public static bool operator !=(MyEquatable<T> lhs, object rhs)
        {
            return Equals(lhs, rhs);
        }
        public abstract bool Equals(T other);
        public abstract override int GetHashCode();
    }
