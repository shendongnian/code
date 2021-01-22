    string line = String.Empty;
    string selectedValue = "00001";
    List<string> matched = new List<string>();
    StreamReader reader = new StreamReader(Path.Combine(masterdin, "MasterANN.txt"));
    while((line = reader.ReadLine()) != null)
    {
        if(line.StartsWith(selectedValue))
        {
            matched.Add(line);
        }
    }
