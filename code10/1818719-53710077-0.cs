    using (var context = new BloggingContext())
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                //Did your work here
                //During this time it will help as a pending lock for other updates
               transaction.Commit();
            }
            catch (Exception)
            {
                // TODO: Handle failure
            }
        }
    }
