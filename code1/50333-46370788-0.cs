    ObjectQuery query =
        new ObjectQuery("SELECT * FROM Win32_LogicalDisk WHERE DriveType=3"); // Create query to select all the hdd's
    ManagementObjectSearcher searcher =
      new ManagementObjectSearcher(scope, query); // run the query
    ManagementObjectCollection queryCollection = searcher.Get(); // get the results
    string sVolumeLabel = "";
    string[,] saReturn = new string[queryCollection.Count, 7];
    int i = 0; // counter for foreach
    foreach (ManagementObject m in queryCollection)
    {
      if (string.IsNullOrEmpty(Convert.ToString(m["VolumeName"]))) { sVolumeLabel = "Local Disk"; } else { sVolumeLabel = Convert.ToString(m["VolumeName"]); } // Disk Label
      string sSystemName = Convert.ToString(m["SystemName"]); // Name of computer
      string sDriveLetter = Convert.ToString(m["Name"]); // Drive Letter
      decimal dSize = Math.Round((Convert.ToDecimal(m["Size"]) / 1073741824), 2); //HDD Size in Gb
      decimal dFree = Math.Round((Convert.ToDecimal(m["FreeSpace"]) / 1073741824), 2); // Free Space in Gb
      decimal dUsed = dSize - dFree; // Used HDD Space in Gb
      
      int iPercent = Convert.ToInt32((dFree / dSize) * 100); // Percentage of free space
            
      saReturn[i,0] = sSystemName;
      saReturn[i,1] = sDriveLetter;
      saReturn[i,2] = sVolumeLabel;
      saReturn[i,3] = Convert.ToString(dSize);
      saReturn[i,4] = Convert.ToString(dUsed);
      saReturn[i,5] = Convert.ToString(dFree);
      saReturn[i,6] = Convert.ToString(iPercent);
      i++; // increase counter. This will add the above details for the next drive.
    }
