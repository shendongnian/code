    public class ItemEqualityComparer<T> : IEqualityComparer<T> where T : class
    {
        private readonly PropertyInfo _propertyInfo;
        public ItemEqualityComparer(string keyItem)
        {
            _propertyInfo = typeof(T).GetProperty(keyItem, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
        }
        public bool Equals(T x, T y)
        {
            var xValue = _propertyInfo?.GetValue(x, null);
            var yValue = _propertyInfo?.GetValue(y, null);
            return xValue != null && yValue != null && xValue.Equals(yValue);
        }
        public int GetHashCode(T obj)
        {
            var propertyValue = _propertyInfo.GetValue(obj, null);
            return propertyValue == null ? 0 : propertyValue.GetHashCode();
        }
    }
