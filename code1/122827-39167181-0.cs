    //Get your IQueryable list of objects from your main DBContext(db)    
    IQueryable<Object> objects = db.Object.Where(whatever where clause you desire);
    //Create a new DBContext outside of the foreach loop    
    using (DBContext dbMod = new DBContext())
    {	
        //Loop through the IQueryable	    
        foreach (Object object in objects)
    	{
            //Get the same object you are operating on in the foreach loop from the new DBContext(dbMod) using the objects id			
            Object objectMod = dbMod.Object.Find(object.id);
			
            //Make whatever changes you need on objectMod
            objectMod.RightNow = DateTime.Now;
            //Invoke SaveChanges() on the dbMod context			
            dbMod.SaveChanges()
	    }
    }
