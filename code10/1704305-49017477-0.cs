		from s in suppliers
		orderby s.District
		join b in buyers on s.District equals b.District into buyersGroup
		select buyersGroup.DefaultIfEmpty(
			new Buyer()
			{
				Name = string.Empty,
				District = s.District
			))
		select new
		{
			Name = bG.Name == null ? string.Empty : bG.Name,
			s.District,
		};
