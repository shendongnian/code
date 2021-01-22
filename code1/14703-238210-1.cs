    public class DeviceOne : IMeasurement<ParametersForDeviceOne>
    {
        public void Init() { }
        public void Close() { }
        public void Setup(ParametersForDeviceOne p) { }
    }
    public class ParametersForDeviceOne : Parameters
    {
    }
