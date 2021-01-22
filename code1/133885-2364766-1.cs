    Type t = typeof(MyClass);
    PropertyInfo pi = t.GetProperty(PropertyName);  
    bool isReadOnly = ReadOnlyAttribute.IsDefined(pi, typeof(ReadOnlyAttribute));
    if (!isReadOnly)
    {
        //check for meta data class.
        MetadataTypeAttribute[] metaAttr = (MetadataTypeAttribute[])t.GetCustomAttributes(typeof(MetadataTypeAttribute),true);
        if (metaAttr.Length > 0)
        {
            foreach (MetadataTypeAttribute attr in metaAttr)
            {
                t = attr.MetadataClassType;
                pi = t.GetProperty(PropertyName);
 
                if (pi != null) isReadOnly = ReadOnlyAttribute.IsDefined(pi, typeof(ReadOnlyAttribute));
                if (isReadOnly) break;
            }
        }
    } 
