    try
    {
        reader = new StreamReader(path);
    }
    catch (Exception)
    {
        // Uh oh something went wrong with opening the file for reading
    }
    string line = reader.ReadLine();
    char character = line[30];
