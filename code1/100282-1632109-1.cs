    private IList<string> SplitIntoChunks(string text, int chunkSize)
    {
        List<string> chunks = new List<string>();
        int offset = 0;
        while (offset < text.Length)
        {
            int size = Math.Min(chunkSize, text.Length - offset);
            chunks.Add(text.Substring(offset, size));
            offset += size;
        }
        return chunks;
    }
