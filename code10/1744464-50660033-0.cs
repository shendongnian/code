    public static void Main(string[] args)
        {
            var character = new Employee();
            Console.Write(character);
        }
    public class Employee
        {
            public Employee()
            {
                Salary = new List<int> { 2, 3, 4 };
            }
    
            public override string ToString()
            {
                return $"{String.Join(", ", Salary)}";
            }
    
            public List<int> Salary { get; set; }
        }
