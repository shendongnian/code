    while (!reader2.EndOfStream)
    {
        string line = reader2.ReadLine();
        if (reader2.EndOfStream && (CheckIfNeedToDeleteLine(line) == false))
        {
            writer2.WriteLine(line);
        }
    }
