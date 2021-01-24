    public class Employee
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int Id { get; set; }
        public overrides string ToString()
        {
            return $"Name: {FName} {LName}, Id: {Id}";
        }
    }
