    public class ListOfBusinessKey
    {
        public Dictionary<string, object> business_key { get; set; }
    }
    public class KeyList
    {
        public int ssid { get; set; }
        public int dim { get; set; }
        public int type { get; set; }
        public List<ListOfBusinessKey> list_of_business_keys { get; set; }
		public DataTable ToDataTable()
        {
            var tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("ssid", typeof(Int64)));
            tbl.Columns.Add(new DataColumn("dim", typeof(Int64)));
            tbl.Columns.Add(new DataColumn("type", typeof(Int64)));
            var columnQuery = EnumerableExtensions.Merge(
				list_of_business_keys
                .SelectMany(k => k.business_key)
                .Select(p => new KeyValuePair<string, Type>(p.Key, p.Value == null ? typeof(object) : p.Value.GetType())),
                p => p.Key, (p1, p2) => new KeyValuePair<string, Type>(p1.Key, MergeTypes(p1.Value, p2.Value)));
            foreach (var c in columnQuery)
                tbl.Columns.Add(c.Key, c.Value);
            foreach (var d in list_of_business_keys.Select(k => k.business_key))
            {
                var row = tbl.NewRow();
                row["ssid"] = ssid;
                row["dim"] = dim;
                row["type"] = type;
                foreach (var p in d.Where(p => p.Value != null))
                {
                    row[p.Key] = Convert.ChangeType(p.Value, tbl.Columns[p.Key].DataType, CultureInfo.InvariantCulture);
                }
                tbl.Rows.Add(row);
            }
            return tbl;
        }
        static Type MergeTypes(Type type1, Type type2)
        {
            // Enhance as needed
            if (type1 == type2)
                return type1;
            if (type2 == typeof(object))
                return type1;
            if (type1 == typeof(object))
                return type2;
            if (type1.IsAssignableFrom(type2))
                return type1;
            if (type2.IsAssignableFrom(type1))
                return type2;
            if (typeof(IConvertible).IsAssignableFrom(type1) && typeof(IConvertible).IsAssignableFrom(type2))
            {
                if (type1 == typeof(string))
                    return type1;
                if (type2 == typeof(string))
                    return type2;
                if ((type1 == typeof(long) || type1 == typeof(int)) && (type2 == typeof(decimal) || type2 == typeof(double)))
                    return type2;
                if ((type2 == typeof(long) || type2 == typeof(int)) && (type1 == typeof(decimal) || type1 == typeof(double)))
                    return type1;
            }
            throw new ArgumentException(string.Format("Cannot merge types {0} and {1}", type1, type2));
        }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> Merge<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TSource, TSource> mergeSelector)
        {
            if (source == null || keySelector == null || mergeSelector == null)
                throw new ArgumentNullException();
            return MergeIterator(source, keySelector, mergeSelector);
        }
        static IEnumerable<TSource> MergeIterator<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TSource, TSource> mergeSelector)
        {
            var dictionary = new Dictionary<TKey, TSource>();
            foreach (TSource element in source)
            {
                var key = keySelector(element);
                TSource oldElement;
                if (!dictionary.TryGetValue(key, out oldElement))
                {
                    dictionary[key] = element;
                }
                else
                {
                    dictionary[key] = mergeSelector(element, oldElement);
                }
            }
            return dictionary.Values;
        }
    }
