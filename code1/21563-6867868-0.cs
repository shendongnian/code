    void OgaraEntities_SavingChanges(object sender, EventArgs e)
    {
      foreach (ObjectStateEntry entry in
          ((ObjectContext)sender).ObjectStateManager.GetObjectStateEntries(
          EntityState.Added ))
      {
        if (!entry.IsRelationship){
          string keyFieldName = entry.EntitySet.ElementType.KeyMembers[0].Name;
          object entity = entry.Entity;
          PropertyInfo pi = entity.GetType().GetProperty(keyFieldName);
          pi.SetValue(entity, Guid.NewGuid(), null);
        }
      }      
    }
