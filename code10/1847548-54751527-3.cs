    using (var context = new DataDbContext())
    {
        var parents = content.Parents.Where(o => o.Children.Any(x => x.Age > 13));
    	foreach (var children in parents.SelectMany(o => o.Children))
    	{
    		children.IsTeenager= true;
    	}
    	
    	context.SaveChanges();
    }
