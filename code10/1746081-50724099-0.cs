    public class Int32ArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] first, int[] second) =>
            first.SequenceEqual(second);
        
        public int GetHashCode(int[] array)
        {
            unchecked
            {
                int hash = 23;
                foreach (var item in array)
                {
                    hash = hash * 31 + item;
                }
                return hash;
            }
        }
    }
