    try
    {
        # SQL Stuff
    }
    catch (SqlException ex)
    {
        if (ex.Errors.Count > 0) // Assume the interesting stuff is in the first error
        {
            switch (ex.Errors[0].Number)
            {
                case 547: // Foreign Key violation
                    throw new InvalidOperationException("Some helpful description", ex);
                    break;
                case 2601: // Primary key violation
                    throw new DuplicateRecordException("Some other helpful description", ex);
                    break;
                default:
                    throw new DataAccessException(ex);
            }
        }
    
    }
