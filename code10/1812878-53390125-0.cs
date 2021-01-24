    var result = employees.Where(e => e.Id == id).Select(e => new Employee
                {
                    Id = e.Id,
                    Projects = e.Projects.SingleOrDefault(p => p.Key == projectKey)
                }).SingleOrDefault();
