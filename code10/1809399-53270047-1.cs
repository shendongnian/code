    public class DataDistinction : IEqualityComparer<Data>
    {
        public bool Equals(Data x, Data y) => x.Value == y.Value;
        public int GetHashCode(Data obj) => obj.Value.GetHashCode();
    }
