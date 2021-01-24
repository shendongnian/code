    var _yourRepository=new TestMongoRepository("connectionstring","database");
 
        
        class Combination{
        public int Sender{get;set;}
        public int Receiver {get;set;}
        }
    var combinations=new List<Combination>{
    new Combination{Sender=1, Receiver=5},
    // add your other comibnaitons here
    
    }
    
    var data= _yourRepository.GetAll<Data>(e =>combinations.Any(c=>c.Sender=e.Sender && c.Receiver=e.Receiver) );
