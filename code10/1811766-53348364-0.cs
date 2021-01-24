    public class ExampleRepository : IRepository {
        private readonly ILogger logger;
        
        public ExampleRepository(ILogger logger){
            this.logger = logger;
        }
        
        //...use logger
    }
    
