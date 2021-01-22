    public class FixedOrderComparer<T> : IComparer<T>
    {
        private readonly T[] fixedOrderItems;
        public FixedOrderComparer(params T[] fixedOrderItems)
        {
            this.fixedOrderItems = fixedOrderItems;
        }
        public int Compare(T x, T y)
        {
            var xIndex = Array.IndexOf(fixedOrderItems, x);
            var yIndex = Array.IndexOf(fixedOrderItems, y);
            xIndex = xIndex == -1 ? int.MaxValue : xIndex;
            yIndex = yIndex == -1 ? int.MaxValue : yIndex;
            return xIndex.CompareTo(yIndex);
        }
    }
