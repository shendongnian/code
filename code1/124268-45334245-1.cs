        // Prints out ICA or RDP session ID of current user 
    
    using System;
    using Microsoft.Win32;
    
    namespace ViaRegedit
    {
        class Program03
        {
            static void Main(string[] args)
            {
                // Obtain an instance of RegistryKey for the CurrentUser registry 
                RegistryKey rkCurrentUser = Registry.CurrentUser;
                // Obtain the test key (read-only) and display it.
                RegistryKey rkTest = rkCurrentUser.OpenSubKey("Remote");
                foreach (string valueName in rkTest.GetSubKeyNames())
                {
                    //Getting path to RDP/Citrix session ID
                    string RDPICApath = "";
                    if (rkTest.OpenSubKey(valueName) != null && rkTest.OpenSubKey(valueName) != null) { RDPICApath = rkTest.OpenSubKey(valueName).ToString(); }
                    Console.WriteLine("Getting CurrentUser ICA-RDP path from string = " + RDPICApath);
                    
                    //Seperating RDPICApath to get session number
                    string RDPICAnumber = RDPICApath.Substring(RDPICApath.LastIndexOf('\\') + 1);
                    Console.WriteLine("Current User RDPICAnumber = " + RDPICAnumber);
                }
                rkTest.Close();
                rkCurrentUser.Close();
                Console.ReadLine();
            }
        }
    
    }
