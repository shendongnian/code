            List<Dept> deptList = new List<Dept>();
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee("d1" + "e1", "A"));
            empList.Add(new Employee("d1" + "e2", "B"));
            empList.Add(new Employee("d1" + "e3", "A"));
            deptList.Add(new Dept("D1", "D1C1", empList));
            
            empList = new List<Employee>();
            empList.Add(new Employee("d2" + "e1", "A"));
            empList.Add(new Employee("d2" + "e2", "B"));
            empList.Add(new Employee("d2" + "e3", "A"));
            deptList.Add(new Dept("D2", "D2C2", empList));
            empList = new List<Employee>();
            empList.Add(new Employee("d3" + "e1", "A"));
            empList.Add(new Employee("d3" + "e2", "B"));
            empList.Add(new Employee("d3" + "e3", "A"));
            deptList.Add(new Dept("D3", "D1C1", empList));
            List<NewModel> result = deptList
                .Where(p => p.Employees != null &&
                    p.Employees
                    .Any(x => x.Type == "A"))  //here this line is no more then just a check and can ignored
                    .GroupBy(g => g.Category,
                    (key, g) => new NewModel
                    {
                        Category = key,
                        EmpNames = g.SelectMany(p => p.Employees.Where( x => x.Type == "A").Select(x => x.Name)).ToList()
                    }).ToList();
