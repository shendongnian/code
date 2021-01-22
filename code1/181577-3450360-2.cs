    List<Tuple<string, string>> IdentityLines = new List<Tuple<string, string>>();//Item1 = filename, Item2 = line
    foreach(FileInfo file in files)
    {
        using(StreamReader sr = new StreamReader(file.FullName) //double check that file.FullName I don't remember for sure if it's right
        {
            while(!string.IsNullOrEmpty(string line = sr.Read())
            {
               if(line.StartsWith("Identity=")) 
                  IdentityLines.Add(file.FileName, line);
            }
        }
    }
