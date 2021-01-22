    public static string PrintObjectProperties(this object obj)
    {
        try
        {
            System.Text.StringBuilder sb = new StringBuilder();
    
            Type t = obj.GetType();
    
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
    
            sb.AppendFormat("Type: '{0}'", t.Name);
    
            foreach (var item in properties)
            {
                object objValue = item.GetValue(obj, null);
    
                sb.AppendFormat("|{0}: '{1}'", item.Name, (objValue == null ? "NULL" : objValue));
            }
    
            return sb.ToString();
        }
        catch
        {
            return obj.ToString();
        }
    }
