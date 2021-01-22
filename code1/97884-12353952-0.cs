    public class MainClass
    {
      public virtual long MainKey {get; set;}
      public virtual SubClass SubInstance {get; set;}
    
      public class SubClass
      {
        public virtual long SubKey {get;set;}
      }
    }
