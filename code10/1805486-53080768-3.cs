     public class Lead
    {
       [Key]
       public int LeadId { get; set; }
    
       public string FirstName { get; set; }
    
       public string LastName { get; set; }
    
       //foreign key to EmployeeId in Employee model
       public int SupervisorId { get; set; }
    
       //second foreign Key to EmployeeId in Employee model
       public int ManagerId { get; set; }
    
       public virtual Manager Manager{ get; set;} 
       public virtual Supervisor Supervisor {get; set;}
    }
