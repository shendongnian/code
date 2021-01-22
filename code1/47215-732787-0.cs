    class Item 
    {
        public string ItemType { get; set; }
        public string Name { get; set; }
    }
    public static T GetValue<T>(string xml) where T : new()
    {
        var omgwtf = Activator.CreateInstance<T>();
        var xmlElement = XElement.Parse(xml);
        foreach (var child in xmlElement.Descendants())
        {
            var property = omgwtf.GetType().GetProperty(child.Name.LocalName);
            if (property != null) 
                property.SetValue(omgwtf, child.Value, null);
        }
        return omgwtf;
    }
