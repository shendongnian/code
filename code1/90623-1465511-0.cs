    [RuleOn(typeof(Entity), FireTime = TimeToFire.TopLevelCommit)]
    internal sealed partial class EntityAddRule : AddRule
    {
      public override void ElementAdded(ElementAddedEventArgs e)
      {
        if (e.ModelElement.Store.InUndoRedoOrRollback)
          return;
        
        if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
          return;
    
        var entity = e.ModelElement as Entity;
    
        if (entity == null)
    	  return;
    
        // InitializeProperties contains the code that used to be in the constructor
        entity.InitializeProperties();
      }
    }
