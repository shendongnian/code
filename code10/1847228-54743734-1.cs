    try
    {
       _context.SaveChanges();
    }
    catch (DbUpdateException e)
    {
        // handle the update exception
    }
    catch (DbEntityValidationException e)
    {
        // handle the entity validation exception
    }
    catch (...)
