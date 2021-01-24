    class Employee
    {
        public int id {get; set;}
        public string name {get; set;}
        public int department_id {get; set;}
        public Departament department {get; set;}
    }
    class Departament
    {
        public int id {get; set;}
        public string name {get; set;}
        //public ICollection<Employee> Employees { get; set; }
    }
