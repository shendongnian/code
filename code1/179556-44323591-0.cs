    class Program
    {
        List<Employee> listOfEmp = new List<Employee>();
        List<Department> listOfDepart = new List<Department>();
        public Program()
        {
            listOfDepart = new List<Department>(){
                new Department { Id = 1, DeptName = "DEV" },
                new Department { Id = 2, DeptName = "QA" },
                new Department { Id = 3, DeptName = "BUILD" },
                new Department { Id = 4, DeptName = "SIT" }
            };
            listOfEmp = new List<Employee>(){
                new Employee { Empid = 1, Name = "Manikandan",DepartmentId=1 },
                new Employee { Empid = 2, Name = "Manoj" ,DepartmentId=1},
                new Employee { Empid = 3, Name = "Yokesh" ,DepartmentId=0},
                new Employee { Empid = 3, Name = "Purusotham",DepartmentId=0}
            };
        }
        static void Main(string[] args)
        {
            Program ob = new Program();
            ob.LeftJoin();
            Console.ReadLine();
        }
        private void LeftJoin()
        {
            listOfEmp.GroupJoin(listOfDepart.DefaultIfEmpty(), x => x.DepartmentId, y => y.Id, (x, y) => new { EmpId = x.Empid, EmpName = x.Name, Dpt = y.FirstOrDefault() != null ? y.FirstOrDefault().DeptName : null }).ToList().ForEach
                (z =>
                {
                    Console.WriteLine("Empid:{0} EmpName:{1} Dept:{2}", z.EmpId, z.EmpName, z.Dpt);
                });
        }
    }
    class Employee
    {
        public int Empid { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
    }
