    // Poco:
    public class Car {
      public int Id {get;set;}
      public string LocalSequenceNumber {get;set;}
      public int ProcessId {get;set; }
      public virtual Process Process {get;set;}
      // ...
    }
    public class Process {
     // ...
    }
    
    // View+Projector:
    public class CarView
    { 
      public int Id {get;set;}
      public string Color {get;set;}
      public string Key {get;set;}
      public static Expression<Func<Car, CarView>> Projector = car => new CarView {
        Id = car.Id,
        Color = car.Color,
        Key = car.Process.Name + " " + car.LocalSequenceNumber 
      }
    }
    
    // calling code
    var car = db.Cars.Select(CarView.Project).SingleOrDefault(cv => cv.Id == id && cv.Key == key)
