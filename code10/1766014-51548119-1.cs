		dgv.DataSource = list.Select(x => new
		{
			x.Name, x.Email, x.Age,
			Roles = string.Join(", ", x.Roles ?? Array.Empty<string>()),
		}).ToList();
	
