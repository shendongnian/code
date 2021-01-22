    Dictionary<string, string> logins = new Dictionary<string, string>();
    foreach (FileInfo file in Files)
    {
        using (StreamReader sr = new StreamReader(file.FullName))
        {
        	for(string line = sr.ReadLine(); !string.IsNullOrEmpty(line); line = sr.ReadLine())
            {
        		if(line.IndexOf("IDENTITY=", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    string login = reg.Match(line).Groups[0].Value;
                    string framew = reg1.Match(line).Groups[0].Value; //added
                    logins.Add(login, framew));
                }
            }
        }
    }
