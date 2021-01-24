    public class VoltageViewModel
    {
          public List<Voltage> Data { get; set; }
            
          public VoltageViewModel()
          {
              Data = new List<Voltage>()
              {
                  new Voltage() { Timestamp = DateTime.Now.AddMinutes(-1), Value = 5.1 },
                  new Voltage() { Timestamp = DateTime.Now.AddMinutes(-2), Value = 4.9 },
                  new Voltage() { Timestamp = DateTime.Now.AddMinutes(-3), Value = 4.85 },
                  new Voltage() { Timestamp = DateTime.Now.AddMinutes(-4), Value = 5.01 }
              };
          }
    
     }
