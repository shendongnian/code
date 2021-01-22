    public class Aircraft
    {
    protected string AircraftName { get; protected set; }
    }
    
    public class F16 : Aircraft
    {
       public F16()
       {
         AircraftName="F16 Falcon";
       }
    }
