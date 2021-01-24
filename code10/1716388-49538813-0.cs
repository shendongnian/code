    try
    {
      using (ZipOutputStream oStream = new ZipOutputStream(File.Create(zipPath)))
      {
        oStream.SetLevel(8); // 9 = highest compression
        for (int j = 0; j < i; j++)
        {
            string fileToZip = sorted.ElementAt(j);
            zipFile(fileToZip, oStream);
        }
        oStream.Finish();
        oStream.Close();
      }
      // Delete the files now.
      for (int j = 0; j < i; j++)
      {
        string fileToZip = sorted.ElementAt(j);
        File.Delete(fileToZip);
      }
      // limitIndex = i - 1;
      startIndex = i - 1;
      zipNumber += 1;
      size = 0;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.ToString());
    } 
