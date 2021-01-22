        private static string SplitNameValuePairs<T>(T value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo property in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (property.GetIndexParameters().Length == 0)
                    sb.AppendFormat("{0}:{1};", property.Name, property.GetValue(value, null));
            }
            return sb.ToString();
        }
