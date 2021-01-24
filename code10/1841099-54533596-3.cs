	using (var db = new MyContext())
	{
		using (var t = db.Database.BeginTransaction())
		{
			var jag = new Car { Brand = "Jaguar", Type = "E" };
			var peter = new Driver { Name = "Peter Sellers", Car = jag };
			db.Drivers.Add(peter);
			db.SaveChanges();
			jag.Driver = peter;
			
			db.SaveChanges();
			t.Commit();
		}
	}
