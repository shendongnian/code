    // Component A (view-model)
    // Runs on main thread     
    void ExecuteUpdateItemCommand()
    {
		try
		{           
		   _itemRepo.BeginTransaction();
		   
		   var item = _itemRepo.GetItem(1);
		   if(item.State == ItemState.First)
		   {
			   itemState.State = ItemState.Second;
			  _itemRepo.UpdateItem(item); // Ideally this should be on a separate thread but for now lets' assume it's on main thread
		   }
		}
		catch
		{
			if (_itemRepo.InTransaction)
			{
				_itemRepo.RollbackTransaction();
			}
			
			throw;
		}
		finally
		{
			if (_itemRepo.InTransaction)
			{
				_itemRepo.CommitTransaction();
			}
		}
    }
    
    // Component B (background service - receives notifications from backedn) 
    // Runs on a background thread
    void OnNotificationReceived()
    {
		try
		{
			_itemRepo.BeginTransaction();
		
			var item = _itemRepo.GetItem(1);
			if(item.State == ItemState.First)
			{
			   item.State = GetNextState(); // some busines logic specific to Component B
			   _itemRepo.UpdateItem(item);
			}
		}
		catch
		{
			if (_itemRepo.InTransaction)
			{
				_itemRepo.RollbackTransaction();
			}
			
			throw;
		}
		finally
		{
			if (_itemRepo.InTransaction)
			{
				_itemRepo.CommitTransaction();
			}
		}
    }
