    public class MyHashtable : Hashtable
    {
        public override int GetHashCode()
        {
            const int seed = 1009;
            const int factor = 9176;
            var hash = seed;
            foreach (var key in Keys)
            {
                hash = hash * factor + key.GetHashCode();
            }
            return hash;
        }
    }
