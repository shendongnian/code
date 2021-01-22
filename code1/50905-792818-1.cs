    WorkOrder w = new WorkOrder();
    Type t = typeof(WorkOrder);
    foreach (XmlNode xl in myXML)
    {
        PropertyInfo pi = t.GetProperty(xl.Name);
        pi.SetValue(w, xl.InnerText, null);
    }
