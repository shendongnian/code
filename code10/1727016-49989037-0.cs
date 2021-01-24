    class User
    {
      public int Id {get; private set;}
      public string Name {get; private set;}
      private int supervisorId;
      public User Supervisor 
      {
        get { ... implement it ... } 
      }
