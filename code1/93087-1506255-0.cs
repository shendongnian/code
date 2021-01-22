    public class Test
    {        
         private RemoteDoc.Documentation docService;     
    
         // Constructor providing default for docService
         public Test()
         {
             docService = new RemoteDoc.Documentation();
         }   
    
         // Constructor for injection
         public Test(RemoteDoc.Documentation serv)       
         { 
              docService = serv;        
         }
    }
