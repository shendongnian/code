    ClientCollection coll = new ClientCollection();
    var results = coll.Select(c =>
    {
    	Dictionary<string, object> objlist = new Dictionary<string, object>();
    	foreach (PropertyInfo pi in c.GetType().GetProperties())
    	{
    		objlist.Add(pi.Name, pi.GetValue(c, null));
    	}
    	return new { someproperty = 1, propertyValues = objlist };
    });
