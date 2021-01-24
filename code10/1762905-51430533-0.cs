    response.GroupBy(x => new { x.Name, x.Stream })
               .SelectMany(g => g.OrderByDescending(row => row.Version).Take(1)) //This gives highest version 
           .Union(response.GroupBy(x => new { x.Name, x.Stream })
               .SelectMany(g => g.OrderByAscending(row => row.Version).Take(1)) // This gives version 0
           .OrderByDescending(o => o.CreatedOn).ToList();
  
