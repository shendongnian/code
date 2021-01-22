    public class Car {
       public Engine { get; set; }
       //more properties here
    }
    
    public class EngineFactory {
      public Engine CreateEngine(EngineType type {
         switch (type) {
            case Big:
               return new BigEngine();
            case Small:
               return new SmallEngine();
         }
      }   
    }
    
    public class Engine {
    
    }
    
    public class BigEngine : Engine {
    
    }
    
    public class SmallEngine : Engine {
    
    }
    
    public class CarCreator {
       public _engineFactory = new EngineFactory();
       //more factories
    
       public Car Create() {
    	Car car = new Car();
        car.Engine = _engineFactory.CreateEngine(ddlEngineType.SelectedValue);
        //more setup to follow
    	return car;
       }
    }
