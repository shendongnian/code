    public class ColumnComparer : IEqualityComparer<object[]>
    {
        private readonly IList<int> _comparedIndexes;
        public ColumnComparer(params int[] comparedIndexes)
        {
            _comparedIndexes = comparedIndexes.ToList();
        }
        #region IEqualityComparer
        public bool Equals(object[] x, object[] y)
        {
            return Object.ReferenceEquals(x, y) || (x != null && y != null && ColumnsEqual(x, y));
        }
        public int GetHashCode(object[] obj)
        {
            return obj == null ? 0 : CombineColumnHashCodes(obj);
        }
        #endregion
        private bool ColumnsEqual(object[] x, object[] y)
        {
            return _comparedIndexes.All(index => ColumnEqual(x, y, index));
        }
        private bool ColumnEqual(object[] x, object[] y, int index)
        {
            return x[index].Equals(y[index]);
        }
        private int CombineColumnHashCodes(object[] row)
        {
            return _comparedIndexes
                .Select(index => obj[index])
                .Aggregate(0, (hashCode, value) => hashCode ^ value);
        }
    }
