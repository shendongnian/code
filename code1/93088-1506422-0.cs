    public class Test
    {        
         private RemoteDoc.IDocumentation docService;     
    
         // Constructor providing default for docService
         public Test()
         {
             docService = new RemoteDoc.Documentation();
         }   
    
         // Constructor for injection
         public Test(RemoteDoc.IDocumentation serv)       
         { 
              docService = serv;        
         }
    }
