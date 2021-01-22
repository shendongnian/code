    public class NamedBackgroundWorker : BackgroundWorker
    {
    
         public string Name;
      
         public BackgroundWorker(string Name)
         {
           this.Name = Name;
         }
    }
