    try
    {
       _context.SaveChanges();
    }
    catch (DbEntityValidationException dbEx)
    {
        var sb = new StringBuilder();
        foreach (var validationErrors in dbEx.EntityValidationErrors)
        {
            foreach (var validationError in validationErrors.ValidationErrors)
            {
               sb.AppendLine(string.Format("Property: {0} Error: {1}",
               validationError.PropertyName,validationError.ErrorMessage));
            }
         }
         throw new Exception(sb.ToString(), dbEx);
    }
