    Dictionary<string, string> yourDictionary = new Dictionary<string, string>();
    string pathF = "C:\\fich.txt";
    StreamReader file = new StreamReader(pathF, Encoding.Default);
    string step = "";
    List<string> stream = new List<string>();
    while ((step = file.ReadLine()) != null)
    {
        if (!string.IsNullOrEmpty(step))
        {
            yourDictionary.Add(step.Substring(0, step.IndexOf(':')), step.Substring(step.IndexOf(':') + 1));
        }
    }
