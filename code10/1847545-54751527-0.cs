    using (var context = new DataDbContext())
    {
    	foreach (var pet in content.Parents.Where(o => o.Children.Any(x => x.Age > 13)).SelectMany(o => o.Children))
    	{
    		pet.IsTeenager= true;
    	}
    	
    	context.SaveChanges();
    }
