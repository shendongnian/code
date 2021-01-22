    private void UnPackLegacyStats()
    {
      DirectoryInfo oDirectory;
      XmlDocument oStatsXml;
      
      //Get the directory
      oDirectory = new DirectoryInfo(msLegacyStatZipsPath);
      //Check if the directory exists
      if (oDirectory.Exists)
      {
        //Loop files
        foreach (FileInfo oFile in oDirectory.GetFiles())
        {
          //Set empty xml
          oStatsXml = null;
          //Load file into a stream
          using (Stream oFileStream = oFile.OpenRead())
          {
            //Check if file is a zip file
            if (C1ZipFile.IsZipFile(oFileStream))
            {
              //Open the zip file
              using (C1ZipFile oZipFile = new C1ZipFile(oFileStream, false))
              {
                //Check if the zip contains the stats
                if (oZipFile.Entries.Contains("Stats.xml"))
                {
                  //Get the stats as a stream
                  using (Stream oStatsStream = oZipFile.Entries["Stats.xml"].OpenReader())
                  {
                    //Load the stats as xml
                    oStatsXml = new XmlDocument();
                    oStatsXml.Load(oStatsStream);
                  }
                }
              }
            }
          }
          //Check if we have stats
          if (oStatsXml != null)
          {
            //Process XML here
          }
          //Delete the file
          oFile.Delete();
        }
      }
    }
