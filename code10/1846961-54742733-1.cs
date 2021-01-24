        .Select(rep => new
        {
            // only Select the rep properties you actually plan to use:
            Id = rep.Id,
            Name = rep.Name,
            ...
            Employees = rep.Employees.Select(employee => new
            {
                // again: select only the properties you plan to use
                Id = employee.Id,
                Name = employee.Name,
                // not needed: foreign key to pm_main_repz
                // pm_main_repzId = rep.pm_main_repzId,
            })
            .ToList(),
            
            Department = new 
            {
                Id = rep.Department,
                ...
            }
            // etc for pm_evt_cat and provencs
        });
