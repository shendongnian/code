      /// <summary>
      /// return Volume Serial Number from hard drive
      /// </summary>
      /// <param name="strDriveLetter">[optional] Drive letter</param>
      /// <returns>[string] VolumeSerialNumber</returns>
      public string GetVolumeSerial(string strDriveLetter)
      {
          if( strDriveLetter=="" || strDriveLetter==null) 
              strDriveLetter="C";
         ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter +":\"");
         disk.Get();
         return disk["VolumeSerialNumber"].ToString();
      }
