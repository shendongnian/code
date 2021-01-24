     public class Unit
    {
        public int UnitId { get; set; }
    
        public string Name { get; set; }
    
    }
    public class Department : Unit 
    {
        public IEnumerable<Division> Divisions { get; set; }
    }
    
    public class Division : Unit 
    {
       public Department Department;
       public int DepartmentId;
    }
