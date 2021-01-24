    using (var context = new DataDbContext())
    {
    	foreach (var child in content.Parents.Where(o => o.Children.Any(x => x.Age > 13)).SelectMany(o => o.Children))
    	{
    		children.IsTeenager= true;
    	}
    	
    	context.SaveChanges();
    }
