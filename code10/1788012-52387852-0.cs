    var currentlyAutomaticPermissions = await context.Permissions
            .Where(x => context.AutomaticPermission
                               .Any(at => at.EmployeeId == x.EmployeeId 
                                       && at.CompanyId == x.CompanyId)
                     && x.IssueDate.Month == DateTime.Today.Month)
            .AsNoTracking()
            .ToListAsync();
