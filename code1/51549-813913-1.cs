    public static void AttachAsModified<T>(
        this ObjectContext ctx, 
        string entitySet, 
        T entity)
    {
        ctx.AttachTo(entitySet, entity);
        
        ObjectStateEntry entry = 
                ctx.ObjectStateManager.GetObjectStateEntry(entity);
        // get all the property names
        var propertyNames = 
                from s in entry.CurrentValues.DataRecordInfo.FieldMetadata
                select s.FieldType.Name;
        // mark every property as modified    
        foreach(var propertyName in propertyNames)
        {
            entry.SetModifiedProperty(propertyName);
        }
    }
