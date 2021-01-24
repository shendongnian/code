    public class DeviceGrain : Grain, IDeviceGrain
    {
        Task Process(TurnOnCommand command) { /* turn on */ }
        Task Process(TurnOffCommand command) { /* turn off */ }
    }
