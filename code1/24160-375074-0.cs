    var unordered = ctx.ActiveUsers
                       .Where(Employee.GetExpression(searchString))
                       .OrderBy(ordering)
                       .Select(u => new Employee {
                           ID = u.ID,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Email = u.Email,
                           CompanyName = u.Company.Name,
                           CompanyID = u.CompanyID.ToString() });
