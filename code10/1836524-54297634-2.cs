    public interface IEmployeeRepository
    {
        IEnumerable<BasicEmployeeData> GetBasicEmployeesData(IEnumerable<int> ids);
        IEnumerable<EmployeeEvaluation> GetEmployeeEvaluations(IEnumerable<int> ids);
        IEnumerable<Employee> GetEmployees(IEnumerable<int> ids);
        IEnumerable<Employee> GetEmployees();
    }
