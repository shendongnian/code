    _context.EmployeeSet.IncludeCommonReferenceses().Select();
`
    internal static class ObjectContextExtensions
    {
        internal static ObjectQuery<Employee> IncludeCommonReferenceses(this ObjectQuery<Employee> employeeSet)
        {
            return employeeSet.Include(GetPropertyName<Employee>(e => e.Department))
               .Include(GetPropertyName<Employee>(e => e.Manager)).Include( ... );
        }
        private static string GetPropertyName<T>(Expression<Func<T, object>> subSelector)
        {
            return ((MemberExpression)subSelector.Body).Member.Name;
        }
    }
