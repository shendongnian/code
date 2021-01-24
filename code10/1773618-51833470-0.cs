    private class Tuple<T1,T2> : IEquatable<Tuple<T1, T2>>
    {
        public T1 First {get;}
        public T2 Second {get;}
        public Tuple(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
        public bool Equals(Tuple<T1, T2> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(First, other.First) && EqualityComparer<T2>.Default.Equals(Second, other.Second);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Tuple<T1, T2>) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T1>.Default.GetHashCode(First) * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Second);
            }
        }
        public static bool operator ==(Tuple<T1, T2> left, Tuple<T1, T2> right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Tuple<T1, T2> left, Tuple<T1, T2> right)
        {
            return !Equals(left, right);
        }
    }
