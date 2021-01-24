    void OnEntityTracked(object sender, EntityTrackedEventArgs e)
    {
    	if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is IHasCreationLastModified entity)
    		entity.Created = DateTime.Now;
    }
    void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
    {
    	if (e.NewState == EntityState.Modified && e.Entry.Entity is IHasCreationLastModified entity)
    		entity.LastModified = DateTime.Now;
    }
    
  
