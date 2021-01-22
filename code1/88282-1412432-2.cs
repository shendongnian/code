    public void GetDiskspace()
        {
          ConnectionOptions options = new ConnectionOptions();
          ManagementScope scope = new ManagementScope("\\\\localhost\\root\\cimv2", 
          options);
          scope.Connect();
          ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
          SelectQuery query1 = new SelectQuery("Select * from Win32_LogicalDisk");
          ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
          ManagementObjectCollection queryCollection = searcher.Get();
          ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(scope, query1);
          ManagementObjectCollection queryCollection1 = searcher1.Get();
          foreach (ManagementObject m in queryCollection)
          {
              // Display the remote computer information
  
              Console.WriteLine("Computer Name : {0}", m["csname"]);
              Console.WriteLine("Windows Directory : {0}", m["WindowsDirectory"]);
              Console.WriteLine("Operating System: {0}", m["Caption"]);
              Console.WriteLine("Version: {0}", m["Version"]);
              Console.WriteLine("Manufacturer : {0}", m["Manufacturer"]);
              Console.WriteLine();
          }
      
          foreach (ManagementObject mo in queryCollection1)
          {
              // Display Logical Disks information
 
             Console.WriteLine("              Disk Name : {0}", mo["Name"]);
             Console.WriteLine("              Disk Size : {0}", mo["Size"]);
             Console.WriteLine("              FreeSpace : {0}", mo["FreeSpace"]);
             Console.WriteLine("          Disk DeviceID : {0}", mo["DeviceID"]);
             Console.WriteLine("        Disk VolumeName : {0}", mo["VolumeName"]);
             Console.WriteLine("        Disk SystemName : {0}", mo["SystemName"]);
             Console.WriteLine("Disk VolumeSerialNumber : {0}", mo["VolumeSerialNumber"]);
             Console.WriteLine();
          }
          string line;
          line = Console.ReadLine(); 
        }
