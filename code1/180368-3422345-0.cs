    Stream data = wClient.OpenRead(url);
    StreamReader read = new StreamReader(data);
    
    List<string> lines = new List<string>();
    
    string nextLine = read.ReadLine();  
    while (nextLine != null)
    {
        lines.Add(nextLine);
        nextLine = read.ReadLine();
    }
    
    textBox1.Lines = lines.ToArray();
