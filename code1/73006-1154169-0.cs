    using (StreamWriter writer = new StreamWriter(filePath, true))
{
    if (!fileExists)
    {
        writer.WriteLine("start");
    }
    writer.WriteLine("data");
    writer.Flush();
