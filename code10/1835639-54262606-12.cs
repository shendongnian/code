    public class SampleContext : ISampleRepository
    {
         private readonly string dbConection;
    
         public SampleContext(IConfiguration configuration) => configuration.GetConnectionString("dbConnection");
    
         ...
     }
