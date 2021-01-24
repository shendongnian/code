    public class HashSetComparer<TItem> : IComparer<HashSet<TItem>>
    {
        private readonly IComparer<TItem> _itemComparer;
        public HashSetComparer(IComparer<TItem> itemComparer)
        {
            _itemComparer = itemComparer;
        }
        public int Compare(HashSet<TItem> x, HashSet<TItem> y)
        {
            foreach (var orderedItemPair in Enumerable.Zip(
                x.OrderBy(item => item, _itemComparer),
                y.OrderBy(item => item, _itemComparer), 
                (a, b) => (a, b))) //C# 7 syntax used - Tuples
            {
                var itemCompareResult = _itemComparer.Compare(orderedItemPair.a, orderedItemPair.b);
                if (itemCompareResult != 0)
                {
                    return itemCompareResult;
                }
            }
            return 0;
        }
    }
