    private static void AttachXmlAttributes(XmlAttributeOverrides xao, List<Type> all, Type t)
    {
        if (all.Contains(t))
        {
            return;
        }
        else
        {
            all.Add(t);
        }
        var list1 = GetAttributeList(t.GetCustomAttributes(false));
        xao.Add(t, list1);
        foreach (var prop in t.GetProperties())
        {
            var propType = prop.PropertyType;
            if (propType.IsGenericType) // is list?
            {
                var args = propType.GetGenericArguments();
                if (args != null && args.Length == 1)
                {                        
                    var genType = args[0];
                    if (genType.Name.ToLower() != "object")
                    {
                        var list2 = GetAttributeList(prop.GetCustomAttributes(false));
                        xao.Add(t, prop.Name, list2);
                        AttachXmlAttributes(xao, all, genType);
                    }                        
                }
            }
            else
            {
                var list2 = GetAttributeList(prop.GetCustomAttributes(false));
                xao.Add(t, prop.Name, list2);
                AttachXmlAttributes(xao, all, prop.PropertyType);
            }
        }
    }        
    private static XmlAttributes GetAttributeList(object[] attributes)
    {
        var list = new XmlAttributes();
        foreach (var attr in attributes)
        {
            Type type = attr.GetType();
            switch (type.Name)
            {
                case "XmlAttributeAttribute":
                    list.XmlAttribute = (XmlAttributeAttribute)attr;
                    break;                    
                case "XmlRootAttribute":
                    list.XmlRoot = (XmlRootAttribute)attr;
                    break;
                case "XmlElementAttribute":
                    list.XmlElements.Add((XmlElementAttribute)attr);
                    break;
                case "XmlArrayAttribute":
                    list.XmlArray = (XmlArrayAttribute)attr;
                    break;
                case "XmlArrayItemAttribute":
                    list.XmlArrayItems.Add((XmlArrayItemAttribute)attr);
                    break;
            }
        }
        return list;
    }
