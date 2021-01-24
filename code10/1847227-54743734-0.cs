    // TODO: create one of your error conditions
    try
    {
       _context.SaveChanges();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.GetType()); // what is the real exception?
    }
