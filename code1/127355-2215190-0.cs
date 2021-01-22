    public IEnumerable<int> GetLineStartIndices(string s)
    {
        yield return 0;
        byte[] chars = Encoding.UTF8.GetBytes(s);
        using (MemoryStream stream = new MemoryStream(chars))
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                while (reader.ReadLine() != null)
                {
                    yield return stream.Position;
                }
            }
        }
    }
