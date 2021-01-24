    public class Worker
    {
      [Key]
      public int Id { get; set; }
    
      [ForeignKey("Farm")]
      public int FarmId { get; set; }
      public Farm Farm { get; set; }
    
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public WorkerType WorkerType {get; set; } // assuming a worker can only be a Farmer or a Driver
    }
