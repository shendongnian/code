    public static string GetValObj(object obj, string propertyName)
    {
        if (obj is JContainer container)
        {
            var nsj = container.First;
            do
            {
                if (string.Equals(nsj.Path, propertyName, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (((JValue)((JProperty)nsj).Value).Value == null)
                        return string.Empty;
                    return ((JValue)((JProperty)nsj).Value).Value
                        .ToString();
                }
    
                nsj = nsj.Next;
            } while (nsj != null);
        }
    
        return obj.GetType().GetProperty(propertyName).GetValue(obj, null).ToString();
    }
