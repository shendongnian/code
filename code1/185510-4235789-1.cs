    private void SingleByteReadThread(object notUsed)
        {
           while (true)
          {
             foreach (FileInfo fi in new DirectoryEnumerator(folderPath))
                      {
                          using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                              fs.ReadByte();    
                      }
            
              Thread.Sleep(TimeSpan.FromSeconds(2));
          }
      }
