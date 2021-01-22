    string path = @"C:\test.txt";
    int count = 0;
    
    if(File.Exists(path))
    {
      using (var reader = new StreamReader(@"c:\test.txt"))
      {
        while (count < 300 && reader.ReadLine() != null)
        {
          count++;
        }
    
        if(count != 300)
        {
          Console.WriteLine("There are less than 300 lines in this file.");
        }
        else
        {
          // keep processing
        }
      }
    }
    else
    {
      Console.WriteLine("File '" + path + "' does not exist.");
    }
