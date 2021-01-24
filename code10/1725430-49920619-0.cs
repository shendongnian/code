     public class Employee
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
    }
