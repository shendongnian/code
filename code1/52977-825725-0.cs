    public class Context
    {
       private static Context _instance;
    
       public static Context Instance
       {
           get
           {
               if (_instance == null)
               {
                   _instance = new Context();
               }
               return _instance;
           }
       }
    
       public Person CurrentlySelectedPerson { get; set; }
    
       private Context() { }
    }
