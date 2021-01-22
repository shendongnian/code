    using System;
    using System.Management;
    using System.Windows.Forms;
    
    public static void Main()
    {
        try
        {
            var searcher =  new ManagementObjectSearcher(
                "root\\CIMV2",
                "SELECT * FROM Win32_MappedLogicalDisk"); 
            foreach (ManagementObject queryObj in searcher.Get())
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Win32_MappedLogicalDisk instance");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Access: {0}", queryObj["Access"]);
                Console.WriteLine("Availability: {0}", queryObj["Availability"]);
                Console.WriteLine("BlockSize: {0}", queryObj["BlockSize"]);
                Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                Console.WriteLine("Compressed: {0}", queryObj["Compressed"]);
                Console.WriteLine("ConfigManagerErrorCode: {0}", queryObj["ConfigManagerErrorCode"]);
                Console.WriteLine("ConfigManagerUserConfig: {0}", queryObj["ConfigManagerUserConfig"]);
                Console.WriteLine("CreationClassName: {0}", queryObj["CreationClassName"]);
                Console.WriteLine("Description: {0}", queryObj["Description"]);
                Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
                Console.WriteLine("ErrorCleared: {0}", queryObj["ErrorCleared"]);
                Console.WriteLine("ErrorDescription: {0}", queryObj["ErrorDescription"]);
                Console.WriteLine("ErrorMethodology: {0}", queryObj["ErrorMethodology"]);
                Console.WriteLine("FileSystem: {0}", queryObj["FileSystem"]);
                Console.WriteLine("FreeSpace: {0}", queryObj["FreeSpace"]);
                Console.WriteLine("InstallDate: {0}", queryObj["InstallDate"]);
                Console.WriteLine("LastErrorCode: {0}", queryObj["LastErrorCode"]);
                Console.WriteLine("MaximumComponentLength: {0}", queryObj["MaximumComponentLength"]);
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
                Console.WriteLine("ProviderName: {0}", queryObj["ProviderName"]);
                Console.WriteLine("Purpose: {0}", queryObj["Purpose"]);
                Console.WriteLine("QuotasDisabled: {0}", queryObj["QuotasDisabled"]);
                Console.WriteLine("QuotasIncomplete: {0}", queryObj["QuotasIncomplete"]);
                Console.WriteLine("QuotasRebuilding: {0}", queryObj["QuotasRebuilding"]);
                Console.WriteLine("SessionID: {0}", queryObj["SessionID"]);
                Console.WriteLine("Size: {0}", queryObj["Size"]);
                Console.WriteLine("Status: {0}", queryObj["Status"]);
                Console.WriteLine("StatusInfo: {0}", queryObj["StatusInfo"]);
                Console.WriteLine("SupportsDiskQuotas: {0}", queryObj["SupportsDiskQuotas"]);
                Console.WriteLine("SupportsFileBasedCompression: {0}", queryObj["SupportsFileBasedCompression"]);
                Console.WriteLine("SystemCreationClassName: {0}", queryObj["SystemCreationClassName"]);
                Console.WriteLine("SystemName: {0}", queryObj["SystemName"]);
                Console.WriteLine("VolumeName: {0}", queryObj["VolumeName"]);
                Console.WriteLine("VolumeSerialNumber: {0}", queryObj["VolumeSerialNumber"]);
            }
        }
        catch (ManagementException ex)
        {
            MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
        }
    }
 
