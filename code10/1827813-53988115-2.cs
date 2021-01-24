        public List<DepartmentModel> GetAllDepartments()
        {
            using (var ctx = new CompanyDbContext())
            {
                // Ensure that related data is loaded
                var departments = ctx.Departments
                    .Include(d => d.Employees);
                // Manual mapping by converting into a new set of models to be used by the Views
                var models = departments
                    .Select(d => new DepartmentModel
                    {
                        Id = d.Id,
                        Employees = d.Employees
                                 .Select(e => new EmployeeModel
                                 {
                                     Id = e.Id,
                                     DepartmentId = e.DepartmentId
                                 })
                                 .ToList(),
                    })
                    .ToList();
                return models;
            }
        }
