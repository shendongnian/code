    static IEnumerable<string> ReadLines(string path, int maxLineLength)
    {
        StringBuilder currentLine = new StringBuilder(maxLineLength);
        using (var reader = File.OpenText(path))
        {
            int i;
            while((i = reader.Read()) > 0) {
                char c = (char) i;
                if(c == '\r' || c == '\n') {
                    yield return currentLine.ToString();
                    currentLine.Length = 0;
                    continue;
                }
                currentLine.Append((char)c);
                if (currentLine.Length > maxLineLength)
                {
                    throw new InvalidOperationException("Max length exceeded");
                }
            }
            if (currentLine.Length > 0)
            {
                yield return currentLine.ToString();
            }                
        }
    }
