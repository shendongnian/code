    var eParam = Expression.Parameter(typeof(Employee), "e");
    
    var comparison = Expression.Lambda(
    	Expression.LessThan(
    		Expression.Property(eParam, "Salary"),
    		Expression.Constant(40000)),
    	eParam);
    
    return from e in db.Employee.Where(comparison)
           select new EmployeeViewModel { Name = e.name, Salary = e.Salary };
