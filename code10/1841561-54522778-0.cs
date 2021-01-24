    public class ExitDetailEntity : Entity
    {
        public int Id {get; set; } //primary key
        public int EmployeeDetailId {get; set; }
        public EmployeeDetailEntity EmployeeDetail {get; set; }
        public ExitStatusEnum ExitStatus {get; set;}
    }
