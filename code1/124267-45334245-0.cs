        // Prints out ICA or RDP session ID of current user & gets ICA session clientAddress variable
    
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
                    
                    //List<string> RDPICAnumber = RDPICApath.Split('\\').ToList();
                    string RDPICAnumber = RDPICApath.Substring(RDPICApath.LastIndexOf('\\') + 1);
                    Console.WriteLine("Current User RDPICAnumber = " + RDPICAnumber);
    
                    //Getting reg local machine info for Citrix based on RDP/Citrix session ID "RDPICAnumber"
                    string regLocal = @"SOFTWARE\Citrix\Ica\Session\" + RDPICAnumber + @"\Connection";
                    RegistryKey localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
                    RegistryKey citrixKey = localKey.OpenSubKey(regLocal);
                    Console.WriteLine("Registry " + citrixKey + " Does Exist - going to get ClientAddress");
                    //getting clietAddress var from citrixKey 
                    string clientAddress = "";
                    if (citrixKey != null && citrixKey.GetValue("clientAddress") != null)
                        {clientAddress = citrixKey.GetValue("clientAddress").ToString();}
                        Console.WriteLine("Getting current user clientAddress from string = " + clientAddress); 
                }
                rkTest.Close();
                rkCurrentUser.Close();
                Console.ReadLine();
            }
        }
    
    }
