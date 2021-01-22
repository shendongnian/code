    public static void Traverse(this IEnumerable<Employee> employees,
                                Action<Employee> action,
                                Func<Employee, bool> predicate)
    {
        foreach (Employee employee in employees)
        {
            action(employee);
            // Recurse down to each employee's employees, etc.
            employee.Employees.Traverse(action, predicate);
        }
    }
