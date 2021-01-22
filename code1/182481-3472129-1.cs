    Dictionary<string,string> identityLines = new Dictionary<string,string>();
    foreach (FileInfo file in Files)
    {
        string line = "";
        using (StreamReader sr = new StreamReader(file.FullName))
        {
            while (!String.IsNullOrEmpty(line = sr.ReadLine()))
            {
                if (line.ToUpper().Contains("IDENTITY="))
                {
                    string login = reg.Match(line).Groups[0].Value;
                    string framew = reg1.Match(line).Groups[0].Value; //added
                    identityLines.Add(login, framew);
                }
            }
    }
