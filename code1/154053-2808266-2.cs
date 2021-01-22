    public Truck : IVehicle
    {
       // MUST implement vehicleEngine and StartEngine:
    
       public Engine vehicleEngine { get; set; }
      
       public bool StartEngine()
       {
           // Trucks needs to do abc to start
       }
    
       public int MaximumLoad { get; set; } // Specific to Truck
    }
