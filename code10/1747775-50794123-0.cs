    try
    {
       string path = @"c:\temp\MyTest.txt";
       // Delete the file if it exists.
       if (File.Exists(path))
       {
          // Note that no lock is put on the
          // file and the possibility exists
          // that another process could do
          // something with it between
          // the calls to Exists and Delete.
          File.Delete(path);
       }
    
       // Create the file.
       using (FileStream fs = File.Create(path))
       {
          Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
          // Add some information to the file.
          fs.Write(info, 0, info.Length);
       }
    
       // Open the stream and read it back.
       using (StreamReader sr = File.OpenText(path))
       {
          string s = "";
          while ((s = sr.ReadLine()) != null)
          {
             Console.WriteLine(s);
          }
       }
    }   
    catch (Exception ex)
    {
        // log
        // message
        // output to a console, or something
        Console.WriteLine(ex.ToString());
    }
