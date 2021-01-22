    public class Car
    {
      State status = Status.Stationary;
    
      public State Status
      {
        get { return status; }
        set { status = value; DoSomething(); }
      }
    }
    
    public class State
    {
    	Stationary, Idle, Moving
    }
