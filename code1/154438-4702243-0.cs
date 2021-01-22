    private static bool DoObjectsMatch(object object1, object object2)
    {
    	var props1 = object1.GetType()
    					.GetProperties()
    					.ToDictionary<PropertyInfo,string,object>(p => p.Name, p => p.GetValue(object1, null));
    	var props2 = object2.GetType()
    					.GetProperties()
    					.ToDictionary<PropertyInfo,string,object>(p => p.Name, p => p.GetValue(object2, null));
    	var query = from prop1 in props1
    				join prop2 in props2 on prop1.Key equals prop2.Key
    				select prop1.Value == null ? prop2.Value == null : prop1.Value.Equals(prop2.Value);
    
    	return query.Count(x => x) == Math.Max(props1.Count(), props2.Count());
    }
