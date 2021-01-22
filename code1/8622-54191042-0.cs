    StreamReader stream = null;
    try { stream = new StreamReader(Path); }
    catch (Exception ex)
    {
        Console.Error.WriteLine("Input open error: " + ex.Message);
        return;
    }
    Console.SetIn(stream);
    int datasize = 0;
    try
    {
        string record = Console.ReadLine();
        while (record != null)
        {
            datasize += record.Length + 2;
            record = Console.ReadLine();
            Console.WriteLine(record);
        }
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Error: {ex.Message}");
        return;
    }
