	ICriteria criteria = this.Repository.CreateCriteria(typeof(House))
	criteria.CreateAlias("AttributeValues", "av");
	criteria.SetFetchMode("av", FetchMode.Select);
	criteria.Add(Expression.Eq("av.Attribute.Name", "door") && Expression.Eq("av.Value", "glass"));
	criteria.Add(Expression.Eq("av.Attribute.Name", "window") && Expression.Eq("av.Value", "big"));
	IList<House> houses = criteria.List<House>();
