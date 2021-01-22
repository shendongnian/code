    public sealed class Singleton
    {
         public static Singleton Instance { get; private set; }
         
         private APIClass _APIClass; 
         private Singleton()
         {
            _APIClass = new APIClass();  
         }
    
         public APIClass API { get { return _APIClass; } }
    
         static Singleton() { Instance = new Singleton(); }     
    }
