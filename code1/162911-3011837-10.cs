    string searchTerm = "Smith";
    var searchResults = employees.Where(e => e.Name.Contains(searchTerm));
    List<Employee> outputList = new List<Employee>();
    Action<IEnumerable<Employee>, List<Employee>> findUnderlings = null;
    findUnderlings = (input, list) =>
    {
        foreach (Employee employee in input)
        {
            list.Add(employee);
            var underlings = employees.Where(e => e.BossId == employee.Id);
            findUnderlings(underlings, list);
        }
    };
    findUnderlings(searchResults, outputList);
