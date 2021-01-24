    using (var context = new DataDbContext())
    {
        var parents = content.Parents.Where(o => o.Children.Any(x => x.Age > 13));
    	foreach (var pet in parents.SelectMany(o => o.Children))
    	{
    		pet.IsTeenager= true;
    	}
    	
    	context.SaveChanges();
    }
