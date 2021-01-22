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
            return ReferenceEquals(x, y) || (x != null && y != null && ColumnsEqual(x, y));
        }
    
        public int GetHashCode(object[] obj)
        {
            return obj == null || !obj.Any() ? 0 : CombineColumnHashCodes(obj);
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
                .Select(index => row[index])
                .Aggregate(0, (hashCode, value) => hashCode ^ value.GetHashCode());
        }
    }
