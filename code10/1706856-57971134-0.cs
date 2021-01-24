    Please follow below steps :
    
    Step1: Create model class 
    
      public class SP_GetService
      {
            [Key]
            public int ServiceId { get; set; }
            public string ServiceAcronym { get; set; }
            public string ServiceDescription { get; set; }
        }
    
    Step2: Create dbset in context file
    
    public virtual DbSet<SP_GetService> SP_GetServices { get; set; }
    
    Step3 : execute procedure 
    
    
    using (var _context = new SampleContext())
    {
     var data = _context.SP_GetServices.FromSql("EXECUTE GetService @Param={0}", "value").ToList();
    }
