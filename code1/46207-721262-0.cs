    using System;
    using Microsoft.Win32;
    namespace WriteToRegistry {
      class Program {
        static void Main(string[] args) {
          const string csRootKey = @"Software\MyCompany\Test";
    
          using (RegistryKey loRegistryKey = Registry.CurrentUser.CreateSubKey(csRootKey)) {
            if (loRegistryKey == null)
              throw new InvalidOperationException("Could not create sub key " + csRootKey);
            loRegistryKey.SetValue("CurrentTime", DateTime.Now.ToString(), RegistryValueKind.String);
          }
        }
      }
    }
