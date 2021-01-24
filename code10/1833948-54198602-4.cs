    namespace MyService
    {
        public partial class MyService : IUser
        {
            ExternalLibrary.User externalUser = new ExternalLibrary.User();
    
            public string GetName()
            {
                return externalUser.GetName();
            }
    
            public bool SetName(string name)
            {
                return externalUser.SetName(name);
            }
        }
    
        public partial class MyService : IDevice
        {
            ExternalLibrary.Device externalDevice = new ExternalLibrary.Device();
    
            public string GetDeviceName()
            {
                return externalDevice.GetDeviceName();
            }
    
            public bool SetDeviceName(string name)
            {
                return externalDevice.SetDeviceName(name);
            }
        }
    }
