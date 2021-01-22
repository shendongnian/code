    public enum Device
    {
        Laptop,
        Mouse,
        Keyboard 
    }
    
    public struct DeviceEvent
    {
        public DeviceEvent(Device device, DateTime timestamp) : this()
        {
            Device = device;
            TimeStamp = timestamp;
        }
        public Device Device { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    
    
    List<DeviceEvent> deviceEvents = new List<DeviceEvent>();
    deviceEvents.Add(new DeviceEvent(Device.Keyboard, DateTime.Now);
    deviceEvents.Add(new DeviceEvent(Device.Mouse, DateTime.Today);
    ... etc
    
    IEnumerable<DeviceEvent> orderedDeviceEvents = deviceEvents.OrderBy(e = > e.TimeStamp);
