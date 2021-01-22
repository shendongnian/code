    IQueryable<Data.Task> query = ctx.DataContext.Tasks;
       
    if (criteria.ProjectId != Guid.Empty)
          query = query.Where(row => row.ProjectId == criteria.ProjectId);
            
    if (criteria.Status != TaskStatus.NotSet)
          query = query.Where(row => row.Status == (int)criteria.Status);
    
    if (criteria.DueDate.DateFrom != DateTime.MinValue)
          query = query.Where(row => row.DueDate >= criteria.DueDate.DateFrom);
    
    if (criteria.DueDate.DateTo != DateTime.MaxValue)
         query = query.Where(row => row.DueDate <= criteria.DueDate.DateTo);
    
    if (criteria.OpenDate.DateFrom != DateTime.MinValue)
         query = query.Where(row => row.OpenDate >= criteria.OpenDate.DateFrom);
    
    var data = query.Select(row => TaskInfo.FetchTaskInfo(row));
