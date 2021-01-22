    public static class ListExtensions
    {
        public static string ExportAsCSV<T>(this IEnumerable<T> listToExport, bool includeHeaderLine, string delimeter)
        {
            StringBuilder sb = new StringBuilder();
            
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();
            if (includeHeaderLine)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(propertyInfo.Name).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }
            foreach (T obj in listToExport)
            {
                T localObject = obj;
                
                var line = String.Join(delimeter, propertyInfos.Select(x => SanitizeValuesForCSV(x.GetValue(localObject, null), delimeter)));
                
                sb.AppendLine(line);
            }
            return sb.ToString();
        }
        private static string SanitizeValuesForCSV(object value, string delimeter)
        {
            string output;
            if (value == null) return "";
            if (value is DateTime)
            {
                output = ((DateTime)value).ToLongDateString();
            }
            else
            {
                output = value.ToString();                
            }
            if (output.Contains(delimeter) || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';
            output = output.Replace("\n", " ");
            output = output.Replace("\r", "");
            return output;
        }
    }
