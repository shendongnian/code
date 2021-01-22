    public class QueryStringKey<T>
    {
        public static implicit operator QueryStringKey<T>(string key)
        {
            return new QueryStringKey<T> { Key = key };
        }
        public string Key { get; set; }
        public T Value
        {
            get
            {
                if (HasValue == false)
                {
                    throw new ArgumentNullException(Key);
                }
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                try
                {
                    return (T)converter.ConvertFromString(_valueString);
                }
                catch
                {
                    return (T)Activator.CreateInstance<T>();
                }
            }
        }
        public bool HasValue
        {
            get
            {
                return !String.IsNullOrEmpty(_valueString);
            }
        }
        private string _valueString
        {
            get
            {
                return HttpContext.Current.Request.QueryString[Key];
            }
        }
    }
    public class QueryStringKeys
    {
        public static QueryStringKey<int> StoreId = "StoreId";
    }
        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (QueryStringKeys.StoredId.HasValue)
                e.InputParameters["StoreId"] = QueryStringKeys.StoreId.Value;
        }
