    public class CustomOrderComparer<TValue> : IComparer<TValue>
    {
        private readonly IComparer<TValue> _fallbackComparer;
        private const int UseDictionaryWhenBigger = 64; // todo - adjust
        private readonly IList<TValue> _customOrder;
        private readonly Dictionary<TValue, uint> _customOrderDict;
        public CustomOrderComparer(IList<TValue> customOrder, IComparer<TValue> fallbackComparer = null)
        {
            _fallbackComparer = fallbackComparer;
            if (customOrder == null) throw new ArgumentNullException("customOrder");
            if (UseDictionaryWhenBigger < customOrder.Count)
            {
                _customOrderDict = new Dictionary<TValue, uint>(customOrder.Count);
                for (int i = 0; i < customOrder.Count; i++)
                    _customOrderDict.Add(customOrder[i], (uint) i);
            }
            else
                _customOrder = customOrder;
        }
        #region IComparer<TValue> Members
        public int Compare(TValue x, TValue y)
        {
            uint indX, indY;
            if (_customOrderDict != null)
            {
                if (!_customOrderDict.TryGetValue(x, out indX)) indX = uint.MaxValue;
                if (!_customOrderDict.TryGetValue(y, out indY)) indY = uint.MaxValue;
            }
            else
            {
                // (uint)-1 == uint.MaxValue
                indX = (uint) _customOrder.IndexOf(x);
                indY = (uint) _customOrder.IndexOf(y);
            }
            if (indX == uint.MaxValue && indY == uint.MaxValue && _fallbackComparer != null)
                return _fallbackComparer.Compare(x, y);
            return indX.CompareTo(indY);
        }
        #endregion
    }
