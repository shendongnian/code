    using System;
    using System.Management;
    using System.Windows.Forms;
    
    namespace WMISample
    {
        public class MyWMIQuery
        {
            public static void Main()
            {
                try
                {
                    ManagementObjectSearcher searcher = 
                        new ManagementObjectSearcher("root\\CIMV2", 
                        "SELECT * FROM Win32_DiskPartition"); 
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Win32_DiskPartition instance");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Access: {0}", queryObj["Access"]);
                        Console.WriteLine("Availability: {0}", queryObj["Availability"]);
                        Console.WriteLine("BlockSize: {0}", queryObj["BlockSize"]);
                        Console.WriteLine("Bootable: {0}", queryObj["Bootable"]);
                        Console.WriteLine("BootPartition: {0}", queryObj["BootPartition"]);
                        Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                        Console.WriteLine("ConfigManagerErrorCode: {0}", queryObj["ConfigManagerErrorCode"]);
                        Console.WriteLine("ConfigManagerUserConfig: {0}", queryObj["ConfigManagerUserConfig"]);
                        Console.WriteLine("CreationClassName: {0}", queryObj["CreationClassName"]);
                        Console.WriteLine("Description: {0}", queryObj["Description"]);
                        Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
                        Console.WriteLine("DiskIndex: {0}", queryObj["DiskIndex"]);
                        Console.WriteLine("ErrorCleared: {0}", queryObj["ErrorCleared"]);
                        Console.WriteLine("ErrorDescription: {0}", queryObj["ErrorDescription"]);
                        Console.WriteLine("ErrorMethodology: {0}", queryObj["ErrorMethodology"]);
                        Console.WriteLine("HiddenSectors: {0}", queryObj["HiddenSectors"]);
                        Console.WriteLine("Index: {0}", queryObj["Index"]);
                        Console.WriteLine("InstallDate: {0}", queryObj["InstallDate"]);
                        Console.WriteLine("LastErrorCode: {0}", queryObj["LastErrorCode"]);
                        Console.WriteLine("Name: {0}", queryObj["Name"]);
                        Console.WriteLine("NumberOfBlocks: {0}", queryObj["NumberOfBlocks"]);
                        Console.WriteLine("PNPDeviceID: {0}", queryObj["PNPDeviceID"]);
    
                        if(queryObj["PowerManagementCapabilities"] == null)
                            Console.WriteLine("PowerManagementCapabilities: {0}", queryObj["PowerManagementCapabilities"]);
                        else
                        {
                            UInt16[] arrPowerManagementCapabilities = (UInt16[])(queryObj["PowerManagementCapabilities"]);
                            foreach (UInt16 arrValue in arrPowerManagementCapabilities)
                            {
                                Console.WriteLine("PowerManagementCapabilities: {0}", arrValue);
                            }
                        }
                        Console.WriteLine("PowerManagementSupported: {0}", queryObj["PowerManagementSupported"]);
                        Console.WriteLine("PrimaryPartition: {0}", queryObj["PrimaryPartition"]);
                        Console.WriteLine("Purpose: {0}", queryObj["Purpose"]);
                        Console.WriteLine("RewritePartition: {0}", queryObj["RewritePartition"]);
                        Console.WriteLine("Size: {0}", queryObj["Size"]);
                        Console.WriteLine("StartingOffset: {0}", queryObj["StartingOffset"]);
                        Console.WriteLine("Status: {0}", queryObj["Status"]);
                        Console.WriteLine("StatusInfo: {0}", queryObj["StatusInfo"]);
                        Console.WriteLine("SystemCreationClassName: {0}", queryObj["SystemCreationClassName"]);
                        Console.WriteLine("SystemName: {0}", queryObj["SystemName"]);
                        Console.WriteLine("Type: {0}", queryObj["Type"]);
                    }
                }
                catch (ManagementException e)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
                }
            }
        }
    }
