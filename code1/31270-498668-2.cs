    public class Car
    {
      EngineState _engineState = EngineState.Stationary;
    
      public EngineState EngineState
      {
        get { return _engineState; }
        set { _engineState = value; DoSomething(); }
      }
    }
    
    public enum EngineState
    {
    	Stationary, Idle, Moving
    }
