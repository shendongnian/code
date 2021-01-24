        [assembly: Dependency(typeof(DeviceInfoService))]
        namespace POC.iOS.DependencyServices
        {
            public class DeviceInfoService:IDeviceInfo
            {
                public DeviceInfoService() { }
                public bool IsIphoneXDevice()
                {
                    if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
                    {
                        if ((UIScreen.MainScreen.Bounds.Height * UIScreen.MainScreen.Scale) == 2436)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
