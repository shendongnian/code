    public class HashSetWithGetHashCode<T> : HashSet<T>
    {
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                foreach (var item in this)
                    hash = hash * 23 + item.GetHashCode();
                return hash;
            }
        }
    }
