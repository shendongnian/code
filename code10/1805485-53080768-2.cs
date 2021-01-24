    public class Supervisor: Employee 
    {
     public int SupervisorId {get; set;}
     public virtual Lead Lead{ get; set;}
     public int LeadId{ get; set;}
     // other properties
     }
