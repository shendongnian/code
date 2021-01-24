    public class PersonDto
    {
        public string Name { get; set; }
    }
    public class StudentDto : PersonDto
    {
        public int studentNumber { get; set; }
    }
    public class EmployeDto  : PersonDto
    {
        public string EmployeId { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
    }
    public class Student : Person
    {
        public int StudentNumber { get; set; }
    }
    public class Employe : Person
    {
        public string EmployeId { get; set; }
    }
