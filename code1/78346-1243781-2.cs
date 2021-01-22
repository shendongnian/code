        public static class ObjectPrettyPrint
        {
            public static string ToString(object obj)
            {
                Type type = obj.GetType();
                PropertyInfo[] props = type.GetProperties();
                StringBuilder sb = new StringBuilder(props.Length*2);
                foreach (var prop in props)
                {
                    sb.Append(prop.Name);
                    sb.Append("=\"");
                    sb.Append(prop.GetValue(obj, null));
                    sb.Append("\" ");
                }
                return sb.ToString();
            }
        }
