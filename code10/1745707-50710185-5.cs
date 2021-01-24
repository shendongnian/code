    public static List<string> GetEmployeeFirstAndLastNames()
    {
        PopulateEmployees();
        return employees.Select(e => e.FirstName + " " + e.LastName)
            .OrderBy(name => name)
            .ToList();
    }
