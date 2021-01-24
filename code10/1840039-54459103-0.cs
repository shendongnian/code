    public class Person
    {
        public string Name { get; set; } //only want this property in all child classes
        public float Salary { get; set; } //don't want to access this property in Student
    }
    interface IStudent
    {
        string Name { get; set; }
        string Subject { get; set; }
    }
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
    }
    public class Student : Person, IStudent
    {
        public string Subject { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IStudent s = new Student() { Name = "Student1", Subject = "Subject1" };
            Console.WriteLine(s.Name);
        }
    }
