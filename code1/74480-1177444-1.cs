    try
    {
        reader = new StreamReader(path);
        string line = reader.ReadLine();
        char character = line[30];
    }
    catch (IOException ex)
    {
        // Uh oh something went wrong with I/O
    }
    catch (Exception ex)
    {
        // Uh oh something else went wrong
    }
