    foreach (Employee employee in employees)
    {
        employee.Underlings = employees.Where(e => e.BossId == employee.Id).ToList();
    }
    List<Employee> newList = new List<Employee>();
    Action<IEnumerable<Employee>, List<Employee>> flattenHierachy = null;
    flattenHierachy = (input, list) =>
    {
        foreach (Employee employee in input)
        {
            list.Add(employee);
            flattenHierachy(employee.Underlings, list);
        }
    };
    flattenHierachy(employees.Where(e => e.BossId == null), newList);
