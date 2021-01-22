    public class Modem : IHardwareDevice
    {
        IIndex<DeviceState, IDeviceState> _states;
        IDeviceState _currentState;
        
        public Modem(IIndex<DeviceState, IDeviceState> states)
        {
             _states = states;
             SwitchOn();
        }
        void SwitchOn()
        {
             _currentState = _states[DeviceState.Online];
        }
    }
