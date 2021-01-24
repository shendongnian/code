    public class Child
    {
      // .. Without virtual
      public Parent Parent { get; set; }
    }
    
    //vs.
    public class Child
    {
      // .. With virtual
      public virtual Parent Parent { get; set; }
    }
