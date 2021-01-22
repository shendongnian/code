    public class DeviceFactory
    {
         public static IDeviceFactory CreateForDevice(IDevice device)
         {
              DeviceType type = device.Type; // or something like this
              switch (type)
              {
                  case DeviceType.Simple: 
                     return new SimpleDeviceFactory();
                 
                  case DeviceType.Complex: 
                     return new ComplexDeviceFactory();
                  default:
                     throw new NotImplementedException();
              }
         }
    }
