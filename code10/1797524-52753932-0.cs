    private IQueryable<Documents> GetQueryByRegistries(DataRange dataRange)
    {    
      // this is your base query. which will be common for all conditions.
      var query = Context.Documents
                              .Where(x => x.Auditoria)
                              .Include(x => x.Variables)
                              .Include(x => x.Events);
      
     switch (dataRange)
     {
        case DataRange.Last10:
            return query.Where(x => x.SomeId == 10).OrderBy(x => x.Creation)
                              .Take(10); // if you want to add Where again you can do that
        case DataRange.Last50:
            return query.OrderBy(x => x.Creation)
                              .Take(50);
                ...
        case DataRange.All:
            return query.OrderBy(x => x.Creation);
        default:
            return query.OrderBy(x => x.Creation);
      }
    }
