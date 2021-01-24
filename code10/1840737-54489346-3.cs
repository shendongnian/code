    public static class Question54484908 
    {
        private static IDictionary<string, PropertyDescriptorCollection> _componentsCache = new Dictionary<string, PropertyDescriptorCollection> ();
        public static IEnumerable<T> Filter<T> (this IEnumerable<T> collection, NameValueCollection filters)
            where T : class 
        {
            if (filters.Count < 1)
                return collection;
            return collection.Where (x => x.InnerFilter (filters));
        }
        internal static bool InnerFilter<T> (this T obj, NameValueCollection filters)
            where T : class 
        {
            Type type = typeof (T);
            PropertyDescriptorCollection typeDescriptor = null;
            if (_componentsCache.ContainsKey (type.Name))
                typeDescriptor = _componentsCache[type.Name];
            else {
                typeDescriptor = TypeDescriptor.GetProperties (type);
                _componentsCache.Add (type.Name, typeDescriptor);
            }
            for (int i = 0; i < filters.Count; i++) {
                string filterName = filters.GetKey (i);
                string filterValue = filters[i];
                PropertyDescriptor propDescriptor = typeDescriptor[filterName];
                if (propDescriptor == null)
                    continue;
                else {
                    string propValue = propDescriptor.GetValue (obj).ToString ();
                    bool isMatch = Regex.IsMatch (propValue, $"({filterValue})");
                    if (isMatch)
                        return true;
                    else
                        continue;
                }
            }
            return false;
        }
    }
