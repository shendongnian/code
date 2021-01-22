    class Program
    {
        public static void Main()
        {
            List<Employee> empList = new List<Employee>() {
               new Employee () {Name = "Test1", Experience = 6 },
               new Employee () {Name = "Test2", Experience = 2 },
              };
            // delegate point to the actual function
            IsPromotable isEligibleToPromote = new IsPromotable(IsEligibleToPromoteEmployee);
            Employee emp = new Employee();
            // pass the delegate to a method where the delegate will be invoked.
            emp.PromoteEmployee(empList, isEligibleToPromote);
            // same can be achieved using lambda empression no need to declare delegate 
            emp.PromoteEmployee(empList, emply => emply.Experience > 2);
            Console.ReadKey();
        }
        // this condition can change at calling end 
        public static bool IsEligibleToPromoteEmployee(Employee emp)
        {
            if (emp.Experience > 5)
                return true;
            else
                return false;
        }
    }
    public delegate bool IsPromotable(Employee emp);
    public class Employee
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        // conditions changes it can 5, 6 years to promote
        public void PromoteEmployee(List<Employee> employees, IsPromotable isEligibleToPromote)
        {
            foreach (var employee in employees)
            {
                // invoke actual function
                if (isEligibleToPromote(employee))
                {
                    Console.WriteLine("Promoted");
                }
            }
        }
    }
