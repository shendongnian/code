        public class HomeController 
        {
            public ITest Test {get; set;}            
        }    
        public class Test : ITest
        {
            public IRepository Repository {get;set;}    
        }
        public class Repository: IRepository
        {
        }
 
