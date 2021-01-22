    XmlAttributes attr = new XmlAttributes();
    var candidateTypes = from t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                         where typeof(A).IsAssignableFrom(t) && !t.IsAbstract
                         select t;
    foreach(Type t in candidateTypes)
    {
        attr.XmlElements.Add(new XmlElementAttribute(t.Name, t));
    }
    
    XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    overrides.Add(typeof(SomeClass), "SomeProperty", attr);
    
    XmlSerializer xs = new XmlSerializer(typeof(SomeClass), overrides);
    ...
