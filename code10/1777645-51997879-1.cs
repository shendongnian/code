    var fields = template.GetType().GetFields().OrderBy(field => field.MetadataToken);
    foreach(var f in fields)
    {
        var isGeneric = f.FieldType.IsGenericType;
        var isList = f.FieldType == typeof(List<NMSTemplate>);
    
        if(isGeneric && isList)
        {                        
            var value = f.GetValue(template);
            var list = (List<NMSTemplate>)value;
    
            foreach(var listEntry in list)
            {
                // ...
            }
        }
    }
