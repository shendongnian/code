    /// <summary>
    /// Find <paramref name="toFind"/> in <paramref name="reader"/>.
    /// </summary>
    /// <param name="reader">The <see cref="TextReader"/> to find <paramref name="toFind"/> in.</param>
    /// <param name="toFind">The string to find.</param>
    /// <returns>Position within <paramref name="reader"/> where <paramref name="toFind"/> starts or -1 if not found.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="reader"/> is null.</exception>
    /// <exception cref="ArgumentException">When <paramref name="toFind"/> is null or empty.</exception>
    public int FindString(TextReader reader, string toFind)
    {
        if(reader == null)
            throw new ArgumentNullException("reader");
        if(string.IsNullOrEmpty(toFind))
            throw new ArgumentException("String to find may not be null or empty.");
        int charsRead = -1;
        int pos = 0;
        int chr;
        do
        {
            charsRead++;
            chr = reader.Read();
            pos = chr == toFind[pos] ? pos + 1 : 0;
        }
        while(chr >= 0 && pos < toFind.Length);
        int result = chr < 0 ? -1 : charsRead - toFind.Length;
        return result < 0 ? -1 : result;
    }
