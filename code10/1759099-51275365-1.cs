    public void AddNewStandardEngineeredModel(StandardEngineeredModel model)
    {
        using (context = new LabelPrintingContext())
        {
            try
            {
                context.EngineeredModels.Add(model);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var sqlException = GetSqlException(ex);
                if (sqlException != null && sqlException.Errors.OfType<SqlError>()
                    .Any(se => se.Number == 2601))
                {
                    // it's a dupe... do something about it
                }
                else
                {
                    // it's something else...
                    throw;
                }
            }
        }
    }
