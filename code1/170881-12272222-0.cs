    public class CsvFileWriter
    {
        public static void WriteToFile<T>(string filePath, List<T> objs, string[] propertyNames)
        {
            var builder = new StringBuilder();
            var propertyInfos = RelevantPropertyInfos<T>(propertyNames);
            foreach (var obj in objs)
                builder.AppendLine(CsvDataFor(obj, propertyInfos));
            File.WriteAllText(filePath, builder.ToString());
        }
        public static void WriteToFileSingleFieldOneLine<T>(string filePath, List<T> objs, string propertyName)
        {
            var builder = new StringBuilder();
            var propertyInfos = RelevantPropertyInfos<T>(new[] { propertyName });
            for (var i = 0; i < objs.Count; i++)
            {
                builder.Append(CsvDataFor(objs[i], propertyInfos));
                if (i < objs.Count - 1)
                    builder.Append(",");
            }
            File.WriteAllText(filePath, builder.ToString());
        }
        private static List<PropertyInfo> RelevantPropertyInfos<T>(IEnumerable<string> propertyNames)
        {
            var propertyInfos = typeof(T).GetProperties().Where(p => propertyNames.Contains(p.Name)).ToDictionary(pi => pi.Name, pi => pi);
            return (from propertyName in propertyNames where propertyInfos.ContainsKey(propertyName) select propertyInfos[propertyName]).ToList();
        }
        private static string CsvDataFor(object obj, IList<PropertyInfo> propertyInfos)
        {
            if (obj == null)
                return "";
            var builder = new StringBuilder();
            for (var i = 0; i < propertyInfos.Count; i++)
            {
                builder.Append(propertyInfos[i].GetValue(obj, null));
                if (i < propertyInfos.Count - 1)
                    builder.Append(",");
            }
            return builder.ToString();
        }
    }
