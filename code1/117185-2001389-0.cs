    class Foo
    {
      private string name;
    
      public string Name 
      { 
        // does not return null when null had been set
        get { return name ?? "No Name"; }
        set { name = value; }
      }
    
    }
