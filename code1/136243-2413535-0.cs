    public static string GetTag<T>(this HtmlHelper h, T myObj, TagBuilder tag)
    {
        Type t = typeof(T);
        tag.Attributes.Add("class", t.Name);
        foreach (PropertyInfo prop in t.GetProperties())
        {
            object propValue = prop.GetValue(myObj, null);
            string stringValue = propValue != null ? propValue.ToString() : String.Empty;
            tag.Attributes.Add(prop.Name, stringValue);
        }
        return tag.ToString();
    }
