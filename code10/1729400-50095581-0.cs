        db.context.Attach(obj);
        DbEntityEntry entry = db.Entry(obj);
        foreach (var proprty in entry.OriginalValues.PropertyNames)
        {
            if(entry.CurrentValues.GetValue<object>(proprty) != null)
            	if (!object.Equals(entry.GetDatabaseValues().GetValue<object>(proprty), entry.CurrentValues.GetValue<object>(proprty)))
            	{
             		entry.Property(proprty).IsModified = true;
        	    }
        }
    
       db.SaveChanges();
