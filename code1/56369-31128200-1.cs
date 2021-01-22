    public class SequenceEqualityComparer<T> : EqualityComparer<IEnumerable<T>>
    {
        readonly IEqualityComparer<T> comparer;
    
        public SequenceEqualityComparer(IEqualityComparer<T> comparer = null)
        {
            this.comparer = comparer ?? EqualityComparer<T>.Default;
        }
    
        public override bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
    		// safer to use ReferenceEquals as == could be overridden
            if (ReferenceEquals(x, y))
                return true;
    
            if (x == null || y == null)
                return false;
    
            var xICollection = x as ICollection<T>;
            if (xICollection != null)
            {
                var yICollection = y as ICollection<T>;
                if (yICollection != null)
                {
                    if (xICollection.Count != yICollection.Count)
                        return false;
    
                    var xIList = x as IList<T>;
                    if (xIList != null)
                    {
                        var yIList = y as IList<T>;
                        if (yIList != null)
                        {
    						// optimization - loops from bottom
                            for (int i = xIList.Count - 1; i >= 0; i--)
                                if (!comparer.Equals(xIList[i], yIList[i]))
                                    return false;
    
                            return true;
                        }
                    }
                }
            }
    
            return x.SequenceEqual(y, comparer);
        }
    
        public override int GetHashCode(IEnumerable<T> sequence)
        {
            unchecked
            {
                int hash = 397;
                foreach (var item in sequence)
                    hash = hash * 31 + comparer.GetHashCode(item);
    
                return hash;
            }
        }
    }
