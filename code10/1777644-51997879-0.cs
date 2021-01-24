    var fields = template.GetType().GetFields().OrderBy(field => field.MetadataToken); 
    foreach(var f in fields)
    {
        var isGeneric = f.FieldType.IsGenericType;
        var isList = f.FieldType == typeof(List<NMSTemplate>);
    
        if(isGeneric && isList)
        {
                            
        }
    }
