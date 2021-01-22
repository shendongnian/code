    public class Car
    {
      VehicleState _vehicleState= VehicleState.Stationary;
    
      public VehicleState VehicleState 
      {
        get { return _vehicleState; }
        set { _vehicleState = value; DoSomething(); }
      }
    }
    
    public enum VehicleState
    {
    	Stationary, Idle, Moving
    }
