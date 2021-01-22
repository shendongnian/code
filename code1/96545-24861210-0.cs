    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    // add a reference to Cassia (MIT license)
    // https://code.google.com/p/cassia/
    
    using Microsoft.Win32; 
    
    namespace RemoteRegistryRead2
    {
        class Program
        {
            static void Main(string[] args)
            {
    			String domain = "theDomain";
    			String user = "theUserName";
    			String password = "thePassword";
    			String host = "machine-x11";
    			
    			
                using (Cassia.UserImpersonationContext userContext = new Cassia.UserImpersonationContext(domain + "\\" + user, password))
                {
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    System.Console.WriteLine("userName: " + userName);
                    
    				RegistryKey baseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, host);
    				RegistryKey key = baseKey.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName");
    
    				String computerName = key.GetValue("ComputerName").ToString();
    				Console.WriteLine(computerName);
                }
            }
        }
    }
