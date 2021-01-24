	var ctx = new DbContext();
	var qry = ctx.contact.Join(ctx.zip_city, c => new { c.zip, c.city }, z => new { z.zip, z.city }, (c, z) => new { c, z })
			   .Select(x => new dtoContact { id = x.c.id }).ToList();
	int count = 0;
	foreach (var con in ctx.contact)
	{
		if (qry.Any(x => x.Id == con.id))
		{
			con.status = "P/O";
		}
		else
		{
			con.status = "???";
		}
		++count;
		if (count % 100 == 0)
		{
			ctx.SaveChanges();
		}
	}
	ctx.SaveChanges();
