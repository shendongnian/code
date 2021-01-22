    public partial class Sheet
    {
        public Item X{ get; set; }
        public Item Y{ get; set; }
        public Item Z{ get; set; }
    
        public IEnumerable<Item> EnumerateItems()
        {
            yield return X;
            yield return Y;
            yield return Z;
            // ...
        }
    }
