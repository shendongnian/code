        var attends = dc.Events                
     .GroupBy(c => c.Employee)
     .Select(x => x.OrderByDescending(y => y.Time).FirstOrDefault())
     .Join(dc.Employees.Where (z=>z.Active), u => u.Employee,o => o.ID, 
            (u, o) => new { o.Name,u.Time,u.EventType}).ToList();
    
    
        
