    public class FrobAndState
    {
      // ... Properties
    
      public FrobAndState Copy()
      {
         var new = new FrobAndState();
         new.State = this.State;
         new.Frobber = this.Frobber;
      }
    }
