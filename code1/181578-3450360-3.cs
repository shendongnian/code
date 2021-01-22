    DirectoryInfo myDir = new DirectoryInfo(@"C:\Testing");
    var Files = myDir.GetFiles("ACCESS*");
    List<KeyValuePair<string, string>> IdentityLines = new List<KeyValuePair<string, string>>();
    foreach(FileInfo file in Files)
    {
        string line = "";
        using(StreamReader sr = new StreamReader(file.FullName))
        {
            while(!String.IsNullOrEmpty(line = sr.ReadLine()))
            {
               if(line.ToUpper().StartsWith("IDENTITY="))
                  IdentityLines.Add(new KeyValuePair<string, string>(file.Name, line));
            }
        }
    }
    foreach(KeyValuePair<string, string> line in IdentityLines) 
    {
        Console.WriteLine("FileName {0}, Line {1}", line.Key, line.Value);
    }
