    public static string ListAllProperties<T>(T obj)
	{
            StringBuilder sb = new System.Text.StringBuilder();
            PropertyInfo[] propInfo = obj.GetType().GetProperties();
            foreach (var prop in propInfo)
            {
                var value = prop.GetValue(obj) ?? "(null)";
                sb.AppendLine(prop.Name + ": " + value.ToString());
            }
            return sb.ToString();
    }
