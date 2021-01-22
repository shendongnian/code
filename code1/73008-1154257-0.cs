    try
    {
        using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("start");
            }
        }
    }
    catch (IOException ex)
    {
    }
    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
        writer.WriteLine("data");
    }
