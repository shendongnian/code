    // rearranged code to avoid horizontal scrolling
    public static string FindSurroundingLines
    (string haystack, string needle, int paddingLines) {
        if (string.IsNullOrEmpty(haystack))
            throw new ArgumentException("haystack");
        else if (string.IsNullOrEmpty(needle))
            throw new ArgumentException("needle");
        else if (paddingLines < 0)
            throw new ArgumentOutOfRangeException("paddingLines");
        // buffer needs to accomodate paddingLines on each side
        // plus line containing the needle itself, so:
        // (paddingLines * 2) + 1
        int bufferSize = (paddingLines * 2) + 1;
        var buffer = new Queue<string>(/*capacity*/ bufferSize);
        using (var reader = new StringReader(haystack)) {
            bool needleFound = false;
            while (!needleFound && reader.Peek() != -1) {
                string line = reader.ReadLine();
                if (buffer.Count == bufferSize)
                    buffer.Dequeue();
                buffer.Enqueue(line);
                needleFound = line.Contains(needle);
            }
            // at this point either the needle has been found,
            // or we've reached the end of the text (haystack);
            // all that's left to do is make sure the string returned
            // includes the specified number of padding lines
            // on either side
            int endingLinesRead = 0;
            while (
                (reader.Peek() != -1 && endingLinesRead++ < paddingLines) ||
                (buffer.Count < bufferSize)
            ) {
                if (buffer.Count == bufferSize)
                    buffer.Dequeue();
                buffer.Enqueue(reader.ReadLine());
            }
            var resultBuilder = new StringBuilder();
            while (buffer.Count > 0)
                resultBuilder.AppendLine(buffer.Dequeue());
            return resultBuilder.ToString();
        }
    }
