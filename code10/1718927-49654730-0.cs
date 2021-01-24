    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WeeklySales { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
