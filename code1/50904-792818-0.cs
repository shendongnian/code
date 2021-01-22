    foreach (XmlNode xl in myXML)
    {
        object o = Assembly.GetExecutingAssembly().CreateInstance("Workorder", true);
        Type t = xl.Name.GetType();
        PropertyInfo pi = t.GetProperty(xl.Name);
        pi.SetValue(o, xl.InnerText, null);
    }
