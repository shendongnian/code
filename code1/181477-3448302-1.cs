    using (FileStream fs = new FileStream(logFilePath, 
                                          FileMode.Open, 
                                          FileAccess.Read,    
                                          FileShare.ReadWrite))
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            while (sr.Peek() >= 0) // reading the old data
            {
               AddLineToGrid(sr.ReadLine());
               index++;
            }
            sr.Close();
        }
    }
