    Type baseType = item.GetType();
    if ((baseType.FullName == "System.Xml.Linq.XElement") && 
    ((obj2 = GetXLinqTagName(item, baseType)) != null))
    {
        baseType = null;
    }
