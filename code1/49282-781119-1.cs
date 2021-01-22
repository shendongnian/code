    while (obj2 != null)
    {
        object obj3 = null;
        if (templateType == typeof(DataTemplate))
        {
            obj3 = new DataTemplateKey(obj2);
        }
        if (obj3 != null)
        {
            keys.Add(obj3);
        }
        if (exactMatch == -1)
        {
            exactMatch = keys.Count;
        }
        if (baseType != null)
        {
            baseType = baseType.BaseType;
            //HERE baseType FullName is XElement
            //Why don't check it again??
            if (baseType == typeof(object))
            {
                baseType = null;
            }
        }
        obj2 = baseType;
    }
