    using (var context = new YourContext())
    {
    	context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    	var data = context.Entity.ToList();
    }
