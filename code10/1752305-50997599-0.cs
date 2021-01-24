    var view = dt.DefaultView.ToTable(true, "DeptId", "DeptName");
    var departments = view.Rows
        .ToLookup(row => row["DeptId"])
        .Select(group => new Depatment
            {
                Id = group.Key, // convert somehow
                Name = group.First()["DeptName"], // convert somehow
                Employees = group.Selec(row => new Employee
                {
                    Id = row["EmpId"], // convert somehow
                    Name = row["EmpName"] // convert somehow
                }).ToList();
            }).ToList();
