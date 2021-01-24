    class Planet {
      public Planet(System system) {System = system;}
      public System System {get; private set;} // singleton
    }
    class System {
      
      public Planet Planet {get; set;}
      // list of planets
      private List<Planet> planets = new List<Planet>();
      public List<Planet> Planets { get {return planets; } }
    }
