    **Employee file:**
    
    namespace CSDrill_Loop
    {
        public class Employee
        {
            public string firstname { get; set; }
            public string lastname { get; set; }
            public int ID { get; set; }
            public Employee(string _firstName, string _lastName, int _ID)
            {
                  firstname = _firstName;
                  lastName = _lastName;
                  ID = _ID;
            }
        }
    }
    
    
    **Program file:**
    
    namespace CSDrill_Loop
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Employee> Employees = new List<Employee>();
                List<string> firstnames = new List<string>()
                {
                    "Bob", "Jeff", "Dale", "Kate", "Ann"
                };
    
                List<string> lastnames = new List<string>()
                {
                    "Jackson", "Smith", "Miller", "Turner", "Johnson"
                };
    
                List<int> IDs = new List<int>()
                {
                    34332, 54754, 43523, 87012, 43158
                };
                for(int i = 0; i < firstNames.length; i++)
                {
                    Employees.Add(new Employee(firstNames[i], lastNames[i], IDs[i]));
                }
            }
        }
    }
