    public bool Update(Entity entity)
    {
        try
        {   
           var entry = _context.Entries.First(e=>e.Id == entity.Id);
           _context.Entry(entry).CurrentValues.SetValues(entity);
    	   _context.SaveChanges();
           return true;
        }
        catch (Exception e)
        {
             // handle correct exception
             // log error
             return false;
        }
    }
