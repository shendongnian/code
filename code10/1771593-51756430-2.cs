    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Skills> Skills { get; set; }
    }
    public class Skills
    {
        public long Id { get; set; }
        public string Skill { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
    public class EmployeeSkills
    {
        public long SkillsId { get; set; }
        public Skills Skills {get; set;}
        public long EmployeeId { get; set; }
        public Employee Employee {get; set;}
    }
