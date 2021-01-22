    public class IEnumerableDiff<T>
    {
        private delegate bool Compare(T x, T y);
        private List<T> _inXAndY;
        private List<T> _inXNotY;
        private List<T> _InYNotX;
        /// <summary>
        /// Compare two IEnumerables.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="compareKeys">True to compare objects by their keys using Data.GetObjectKey(); false to use object.Equals comparison.</param>
        public IEnumerableDiff(IEnumerable<T> x, IEnumerable<T> y, bool compareKeys)
        {
            _inXAndY = new List<T>();
            _inXNotY = new List<T>();
            _InYNotX = new List<T>();
            Compare comparer = null;
            bool hit = false;
            if (compareKeys)
            {
                comparer = CompareKeyEquality;
            }
            else
            {
                comparer = CompareObjectEquality;
            }
            
            foreach (T xItem in x)
            {
                hit = false;
                foreach (T yItem in y)
                {
                    if (comparer(xItem, yItem))
                    {
                        _inXAndY.Add(xItem);
                        hit = true;
                        break;
                    }
                }
                if (!hit)
                {
                    _inXNotY.Add(xItem);
                }
            }
            foreach (T yItem in y)
            {
                hit = false;
                foreach (T xItem in x)
                {
                    if (comparer(yItem, xItem))
                    {
                        hit = true;
                        break;
                    }
                }
                if (!hit)
                {
                    _InYNotX.Add(yItem);
                }
            }
        }
        /// <summary>
        /// Adds and removes items from the x (current) list so that the contents match the y (new) list.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="compareKeys"></param>
        public static void SyncXList(IList<T> x, IList<T> y, bool compareKeys)
        {
            var diff = new IEnumerableDiff<T>(x, y, compareKeys);
            foreach (T item in diff.InXNotY)
            {
                x.Remove(item);
            }
            foreach (T item in diff.InYNotX)
            {
                x.Add(item);
            }
        }
        public IList<T> InXAndY
        {
            get { return _inXAndY; }
        }
        public IList<T> InXNotY
        {
            get { return _inXNotY; }
        }
        public IList<T> InYNotX
        {
            get { return _InYNotX; }
        }
        public bool ContainSameItems
        {
            get { return _inXNotY.Count == 0 && _InYNotX.Count == 0; }
        }
        private bool CompareObjectEquality(T x, T y)
        {
            return x.Equals(y);
        }
        private bool CompareKeyEquality(T x, T y)
        {
            object xKey = Data.GetObjectKey(x);
            object yKey = Data.GetObjectKey(y);
            return xKey.Equals(yKey);
        }
    }
