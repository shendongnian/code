    public static IEnumerable<string> ReadLines(Stream input)
    {
        // Note: don't close the StreamReader - we don't own the stream!
        StreamReader reader = new StreamReader(input);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }
