    public partial class Sheet : IEnumerable<Item>
    {
        public Item X{ get; set; }
        public Item Y{ get; set; }
        public Item Z{ get; set; }
    
        private IEnumerable<Item> EnumerateItems()
        {
            yield return X;
            yield return Y;
            yield return Z;
            // ...
        }
        public IEnumerator<Item> GetEnumerator()
        {
            return EnumerateItems().GetEnumerator();
        }
        IEnumerator IEnumerator.GetEnumerator()
        {
            return EnumerateItems().GetEnumerator();
        }
    }
