    while ((line = reader.ReadLine()) != null)
    {
        foreach (char Character in line)
        {
            i++;
            OutputDebug(i.ToString());
        }
    }
