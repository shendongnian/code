    /// <summary>
    /// Sets all properties on an object to modified.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="entity">The entity.</param>
    private static void SetAllPropertiesModified(ObjectContext context, object entity) {
        var stateEntry = context.ObjectStateManager.GetObjectStateEntry(entity);
        // Retrieve all the property names of the entity
        var propertyNames = stateEntry.CurrentValues.DataRecordInfo.FieldMetadata.Select(fm => fm.FieldType.Name);
        foreach(var propertyName in propertyNames) {// Set each property as modified
            stateEntry.SetModifiedProperty(propertyName);
        }
    }
