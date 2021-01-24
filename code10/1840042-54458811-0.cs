    private class Device
    {
       public string Name { get; set; }
       public Func<double,double> Conversion { get; set; }
       public string Unit { get; set; }
    }
            
    public static object ParseDecentLab(byte[] bytes)
    {        
       List<Device> deviceList = new List<Device>()
       {
          new Device()
          {
             Name = "battery-voltage",
             Conversion = (x) => x / 1000,
             Unit = "V"
          },
          new Device()
          {
             Name = "air-temperature",
             Conversion = (x) => (175 * x / 65535) - 45,
             Unit = "°C"
          }
       };
    }
