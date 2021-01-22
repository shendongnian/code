    object[] GetPrimaryKeyValue(DbEntityEntry entry)
    {
        List<object> key = new List<object>();
    
        var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
        if (objectStateEntry.EntityKey.EntityKeyValues != null && objectStateEntry.EntityKey.EntityKeyValues.Length==1)
        {
            key.Add(objectStateEntry.EntityKey.EntityKeyValues[0].Value);
        }
        else
        {
            if (objectStateEntry.EntitySet.ElementType.KeyMembers.Any())
            {
                foreach (var keyMember in objectStateEntry.EntitySet.ElementType.KeyMembers)
                {
                    if (entry.CurrentValues.PropertyNames.Contains(keyMember.Name))
                    {
                        var memberValue = entry.CurrentValues[keyMember.Name];
                        if (memberValue != null)
                        {
                            key.Add(memberValue);
                        }
                    }
                }
            }
        }
        return key.ToArray();
    }
