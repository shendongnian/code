    try
    {
        reader = new StreamReader(path);
        string line = reader.ReadLine();
        char character = line[30];
    }
    catch (IOException)
    {    
    }
