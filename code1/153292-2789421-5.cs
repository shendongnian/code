    public partial class Sheet : IEnumerable<Item>
    {
        public Item X{ get; set; }
        public Item Y{ get; set; }
        public Item Z{ get; set; }
    
        public IEnumerator<Item> GetEnumerator()
        {
            yield return X;
            yield return Y;
            yield return Z;
            // ...
        }
        IEnumerator IEnumerator.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
