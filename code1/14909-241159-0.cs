    using System;
    using System.Runtime.InteropServices;
    namespace PowerStateExample
    {
        [StructLayout(LayoutKind.Sequential)]
        public class PowerState
        {
            public ACLineStatus ACLineStatus;
            public BatteryFlag BatteryFlag;
            public Byte BatteryLifePercent;
            public Byte Reserved1;
            public Int32 BatteryLifeTime;
            public Int32 BatteryFullLifeTime;
            // direct instantation not intended, use GetPowerState.
            private PowerState() {}
            public static PowerState GetPowerState()
            {
                PowerState state = new PowerState();
                if (GetSystemPowerStatusRef(state))
                    return state;
                
                throw new ApplicationException("Unable to get power state");
            }
            [DllImport("Kernel32", EntryPoint = "GetSystemPowerStatus")]
            private static extern bool GetSystemPowerStatusRef(PowerState sps);
        }
        
        // Note: Underlying type of byte to match Win32 header
        public enum ACLineStatus : byte
        {
            Offline = 0, Online = 1, Unknown = 255
        }
        public enum BatteryFlag : byte
        {
            High = 1, Low = 2, Critical = 4, Charging = 8,
            NoSystemBattery = 128, Unknown = 255
        }
        // Program class with main entry point to display an example.
        class Program
        {        
            static void Main(string[] args)
            {
                PowerState state = PowerState.GetPowerState();
                Console.WriteLine("AC Line: {0}", state.ACLineStatus);
                Console.WriteLine("Battery: {0}", state.BatteryFlag);
                Console.WriteLine("Battery life %: {0}", state.BatteryLifePercent);
            }
        }
    }
