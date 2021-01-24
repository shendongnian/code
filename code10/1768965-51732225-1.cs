    using System.Management;
    
    namespace YourWPFApp
    {
        public class KeyboardFilter
        {
            public static void DisablePredfinedKey(string keyId)
            {
                ManagementScope scope = new ManagementScope
                {
                    Path = new ManagementPath
                    {
                        NamespacePath = @"root\standardcimv2\embedded",
                        ClassName = "WEKF_PredefinedKey"
                    }
                };
                ManagementClass wekfPredefinedKey = new ManagementClass(scope.Path);
                var output = wekfPredefinedKey.InvokeMethod("Enable", new object[] { keyId });
            }
        }
    }
