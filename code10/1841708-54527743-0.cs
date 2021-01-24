	var clientRoles = new []
	{
		new { ClientId = 101, Role = "READ", RowVersion = 2 },
		new { ClientId = 101, Role = "WRITE", RowVersion = 1 },
		new { ClientId = 102, Role = "ADMIN", RowVersion = 3 },
		new { ClientId = 102, Role = "READ", RowVersion = 2 },
	};
	var result =
		from cr in clientRoles
		orderby cr.ClientId, cr.RowVersion descending
		group cr by cr.ClientId into gs
		from g in gs.Take(1)
		select g;
