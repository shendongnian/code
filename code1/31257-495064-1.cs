    public class Car
    {
      public enum State
      {
        Off,
        Starting,
        Moving
      };
    
      State state = State.Off;
    
      public State Status
      {
        get { return state ; }
        set { state= value; DoSomething(); }
      }
    }
