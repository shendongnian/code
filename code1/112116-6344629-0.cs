    public class Employee
    {
        public string EmployeeNumber { get; set; }
        public DateTime? HireDate { get; set; }
    }
    public class EmployeeCollection : List<Employee>
    { }
    private void RunTest()
    {
        EmployeeCollection empcoll = new EmployeeCollection();
        empcoll.Add(new Employee() { EmployeeNumber = "1111", HireDate = DateTime.Now });
        empcoll.Add(new Employee() { EmployeeNumber = "3333", HireDate = DateTime.Now });
        empcoll.Add(new Employee() { EmployeeNumber = "2222", HireDate = null });
        empcoll.Add(new Employee() { EmployeeNumber = "4444", HireDate = null });
        //Here's the "money" line!
        empcoll.Where(x => x.HireDate.HasValue == false).ToList().ForEach(item => ReportEmployeeWithMissingHireDate(item.EmployeeNumber));
    }
    private void ReportEmployeeWithMissingHireDate(string employeeNumber)
    {
        Console.WriteLine("We need to find a HireDate for '{0}'!", employeeNumber);
    }
