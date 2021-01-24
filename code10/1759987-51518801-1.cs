    public class DuplicateFreeCache<TKey, TItem> where TItem : class
    {
        private ConcurrentDictionary<TKey, int> Primary { get; } = new ConcurrentDictionary<TKey, int>();
        private List<TItem> ItemList { get; } = new List<TItem>();
        private List<TItem[]> ListList { get; } = new List<TItem[]>();
        private Dictionary<TItem, int> ItemDict { get; } = new Dictionary<TItem, int>();
        private Dictionary<IntArray, int> ListDict { get; } = new Dictionary<IntArray, int>();
        public IReadOnlyList<TItem> GetOrAdd(TKey key, Func<TKey, IEnumerable<TItem>> getFunc)
        {
            int index = Primary.GetOrAdd(key, k =>
            {
                var rawList = getFunc(k);
                lock (Primary)
                {
                    int[] itemListByIndex = rawList.Select(item =>
                    {
                        if (!ItemDict.TryGetValue(item, out int itemIndex))
                        {
                            itemIndex = ItemList.Count;
                            ItemList.Add(item);
                            ItemDict[item] = itemIndex;
                        }
                        return itemIndex;
                    }).ToArray();
                    var intArray = new IntArray(itemListByIndex);
                    if (!ListDict.TryGetValue(intArray, out int listIndex))
                    {
                        lock (ListList)
                        {
                            listIndex = ListList.Count;
                            ListList.Add(itemListByIndex.Select(ii => ItemList[ii]).ToArray());
                        }
                        ListDict[intArray] = listIndex;
                    }
                    return listIndex;
                }
            });
            lock (ListList)
            {
                return ListList[index];
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"A cache with:");
            sb.AppendLine($"{ItemList.Count} unique Items;");
            sb.AppendLine($"{ListList.Count} unique lists of Items;");
            sb.AppendLine($"{Primary.Count} primary dictionary items;");
            sb.AppendLine($"{ItemDict.Count} item dictionary items;");
            sb.AppendLine($"{ListDict.Count} list dictionary items;");
            return sb.ToString();
        }
        //We have this to make Dictionary lookups on int[] find identical arrays.
        //One could also just make an IEqualityComparer, but I felt like doing it this way.
        public class IntArray
        {
            private readonly int _hashCode;
            public int[] Array { get; }
            public IntArray(int[] arr)
            {
                Array = arr;
                unchecked
                {
                    _hashCode = 0;
                    for (int i = 0; i < arr.Length; i++)
                        _hashCode = (_hashCode * 397) ^ arr[i];
                }
            }
            protected bool Equals(IntArray other)
            {
                return Array.SequenceEqual(other.Array);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((IntArray)obj);
            }
            public override int GetHashCode() => _hashCode;
        }
    }
