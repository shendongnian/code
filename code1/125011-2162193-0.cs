    public class Properties<T>
    {
        private Dictionary<string, T> _dict = new Dictionary<string, T>();
        public void SetPropertyValue<T>(string propertyIdCode, T value)
        {
            _dict[propertyIdCode] = value;
        }
        public T GetPropertyValue<T>(string propertyIdCode)
        {
            return _dict[propertyIdCode];
        }
    }
