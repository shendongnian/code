    public static class EmployerExtensions
    {
        public static void Traverse(this Employer employer, Action<Employee> action)
        {
            // check employer and action for null and throw if they are
            foreach (var employee in employer.Employees)
            {
                action(employee);
            }
        }
    }
