    public class Manager: Employee 
    {
     public int ManagerId {get; set;}
 
     public int LeadId{ get; set;}
     public virtual Lead Lead{ get; set;}
     // other properties
     }
