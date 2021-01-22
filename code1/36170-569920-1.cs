    using System;
    using System.Collections.Generic;
    
    public sealed class Pair<TFirst, TSecond>
        : IEquatable<Pair<TFirst, TSecond>>
    {
        private readonly TFirst first;
        private readonly TSecond second;
        public Pair(TFirst first, TSecond second)
        {
            this.first = first;
            this.second = second;
        }
        public TFirst First
        {
            get { return first; }
        }
        public TSecond Second
        {
            get { return second; }
        }
        public bool Equals(Pair<TFirst, TSecond> other)
        {
            if (other == null)
            {
                return false;
            }
            return EqualityComparer<TFirst>.Default.Equals(this.First, other.First) &&
                   EqualityComparer<TSecond>.Default.Equals(this.Second, other.Second);
        }
        public override bool Equals(object o)
        {
            return Equals(o as Pair<TFirst, TSecond>);
        }
        public override int GetHashCode()
        {
            return EqualityComparer<TFirst>.Default.GetHashCode(first) * 37 +
                   EqualityComparer<TSecond>.Default.GetHashCode(second);
        }
    }
