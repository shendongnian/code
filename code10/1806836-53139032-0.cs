    public async Task<List<Property>> GetProperties()
    {
    	using(var db = new ApplicationDbContext())
    	{
    		var properties = await (from p in db.Properties
    						  join pt in db.PropertyTypes
    						  on p.PropertyTypeId equals pt.PropertyTypeId
    						  select new Property()
    						  {
    							  PropertyId = p.PropertyId,
    							  PropertyName = p.PropertyName,
    							  Owner = p.Owner,
    							  Cluster = p.Cluster,
    							  PropertyNumber = p.PropertyNumber,
    							  RegionCode = p.RegionCode,
    							  ProvinceCode = p.ProvinceCode,
    							  MunicipalCode = p.MunicipalCode,
    							  BarangayCode = p.BarangayCode,
    							  DateAdded = p.DateAdded,
    							  DateModified = p.DateModified,
    							  PropertyTypeId = p.PropertyTypeId,
    							  PropertyType = p.PropertyType,
    							  Type = pt.Type
    						  }).ToListAsync();
    
    		return properties;
    	}
    }
