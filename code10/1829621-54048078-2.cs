    public class Employee
    {
        private string Name;
        private int Income;
    
        public string FullName
        {
            set { Name = value;}
            get { return Name; }
        }
    
        public int Salary
        {
            set { Income = value; }
            get { return Income; }
        }
        public override string ToString()
        {
            return string.Format("Employee Name: {0}, Salary: {1}", Name, Salary);
        }
    }
    static void Main(string[] args)
    {
        Employee[] customArray = new Employee[3];
        customArray[0] = new Employee()
        {
            FullName = "John Doe",
            Salary = 100000
        };
        customArray[1] = new Employee()
        {
            FullName = "Mary Jane",
            Salary = 50000
        };
        customArray[2] = new Employee()
        {
            FullName = "Tyler Smith",
            Salary = 80000
        };
        for (int i = 0; i < employee.Length; i++)
        {
            Console.Write(employee[i].ToString() + "\n");
        }
        Console.ReadLine();
    }
