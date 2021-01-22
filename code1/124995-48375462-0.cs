    List<string> Words = new List<string>();
    
    using (StreamReader sr = new StreamReader(@"C:\Temp\file.txt"))
    {
    string line = string.Empty;
    while ((line = sr.ReadLine()) != null)
    {
        Words.Add(line);
    }
    }
