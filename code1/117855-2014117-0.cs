    // Get an IQueryable of anonymous types.
    var query = from p in db.PeopleTable /* Assume Linq to SQL */
                select new { Name = p.Name, Age = p.Age };
    // Execute the query and pull the results into an IEnumerable of anonymous types
    var enum = query.AsEnumerable();
    // Use Linq to Objects methods to further refine.
    var refined = from p in enum
                  select new
                  {
                      Name = GetPrettyName(p.Name),
                      DOB = CalculateDOB(p.Age, DateTime.Now)
                  };
