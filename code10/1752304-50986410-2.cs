    IList<Department> departments =
            table.AsEnumerable()
            .GroupBy(d => new
            {
                Id = d.Field<Int32>("DeptId"),
                Name = d.Field<String>("DeptName")
            })
            .Select(grp =>
                new Department
                {
                    Id = grp.Key.Id,
                    Name = grp.Key.Name
                }).ToList();
