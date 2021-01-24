    // Let's implement immutable class (assigned once, never change)
    // in order to prevent occasional errors like device.Name = ... 
    private class Device {
      public string Name { get; }
      public Func<double, double> Conversion { get; }
      public string Unit { get; }
      // Let's validate the input (at least, for null)
      public Device(string name, Func<double, double> conversion, string unit) {
        if (null == name)
          throw new ArgumentNullException(nameof(name));
        else if (null == conversion)
          throw new ArgumentNullException(nameof(conversion));
        else if (null == unit)
          throw new ArgumentNullException(nameof(unit));
        Name = name;
        Conversion = conversion;
        Unit = unit;
      }
    }
    ...
    List<Device> deviceList = new List<Device>() {
      new Device("battery-voltage", x => x / 1000, "V"),
      new Device("air-temperature", x => (175 * x / 65535) - 45, "°C"),
    };
