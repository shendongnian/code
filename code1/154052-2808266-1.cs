    public Car : IVehicle
    {
       // MUST implement vehicleEngine and StartEngine:
    
       public Engine vehicleEngine { get; set; }
      
       public bool StartEngine()
       {
           // Cars needs to do xyz to start
       }
    
       public int MaxNumberOfPassenger { get; set; } // Specific to Car
    }
