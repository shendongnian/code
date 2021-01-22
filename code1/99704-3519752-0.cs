    public static class ObjectExtensions
    {
        /// <summary>
        /// Turn anonymous object to dictionary
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this object data)
        {
            var attr = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            foreach (var property in data.GetType().GetProperties(attr))
            {
                if (property.CanRead)
                {
                    dict.Add(property.Name, property.GetValue(data, null));
                }
            }
            return dict;
        }
    }
