 	using (var db = new MyDbContext(opts))
    using (var transaction = db.BeginTransaction())
	{
		var record = db.Record.FirstOrDefault(x => x.Id == id);
		if(record == null) return;
		record.FieldN = ...
		db.Update(record);
		db.Other.RemoveRange(db.Other.Where(x => x.EntityId == id));
		db.SaveChanges();
        transaction.Commit();
	}   
