    public class CustomOrderComparer<TValue> : IComparer<TValue>
    {
        private const int UseDictionaryWhenBigger = 64;
        private readonly IList<TValue> _customOrder;
        private readonly Dictionary<TValue, int> _customOrderDict;
        public CustomOrderComparer(IList<TValue> customOrder)
        {
            if (customOrder == null) throw new ArgumentNullException("customOrder");
            if (UseDictionaryWhenBigger < customOrder.Count)
            {
                _customOrderDict = new Dictionary<TValue, int>(customOrder.Count);
                for (int i = 0; i < customOrder.Count; i++)
                    _customOrderDict.Add(customOrder[i], i);
            }
            else
                _customOrder = customOrder;
        }
        #region IComparer<TValue> Members
        public int Compare(TValue x, TValue y)
        {
            if (_customOrderDict != null)
            {
                int s1, s2;
                if (!_customOrderDict.TryGetValue(x, out s1)) s1 = Int32.MaxValue;
                if (!_customOrderDict.TryGetValue(y, out s2)) s2 = Int32.MaxValue;
                return s1.CompareTo(s2);
            }
            else
            {
                // (uint)-1 == uint.MaxValue
                var s1 = (uint) _customOrder.IndexOf(x);
                var s2 = (uint) _customOrder.IndexOf(y);
                return s1.CompareTo(s2);
            }
        }
        #endregion
    }
