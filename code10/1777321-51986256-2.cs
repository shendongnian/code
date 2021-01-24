    public static int CountOccurences(Stream stream, string searchString, Encoding encoding = null, int bufferSize = 4096)
    {
        if (stream == null)
            throw new ArgumentNullException(nameof(stream));
        if (searchString == null)
            throw new ArgumentNullException(nameof(searchString));
        if (!stream.CanRead)
            throw new ArgumentException("Stream must be readable.", nameof(stream));
        if (bufferSize <= 0)
            throw new ArgumentException("Buffer size must be a positive number.", nameof(bufferSize));
        // detecting encoding
        Span<byte> bom = stackalloc byte[4];
        var actualLength = stream.Read(bom);
        if (actualLength == 0)
            return 0;
        bom = bom.Slice(0, actualLength);
        Encoding detectedEncoding;
        if (bom.StartsWith(Encoding.UTF8.GetPreamble()))
            detectedEncoding = Encoding.UTF8;
        else if (bom.StartsWith(Encoding.UTF32.GetPreamble()))
            detectedEncoding = Encoding.UTF32;
        else if (bom.StartsWith(Encoding.Unicode.GetPreamble()))
            detectedEncoding = Encoding.Unicode;
        else if (bom.StartsWith(Encoding.BigEndianUnicode.GetPreamble()))
            detectedEncoding = Encoding.BigEndianUnicode;
        else
            detectedEncoding = null;
        if (detectedEncoding != null)
        {
            if (encoding == null)
                encoding = detectedEncoding;
            if (encoding == detectedEncoding)
                bom = bom.Slice(detectedEncoding.GetPreamble().Length);
        }
        else if (encoding == null)
            encoding = Encoding.ASCII;
        // acquiring a buffer
        ReadOnlySpan<byte> searchBytes = encoding.GetBytes(searchString);
        bufferSize = Math.Max(Math.Max(bufferSize, searchBytes.Length), 128);
        var bufferArray = ArrayPool<byte>.Shared.Rent(bufferSize);
        try
        {
            var buffer = new Span<byte>(bufferArray, 0, bufferSize);
            // looking for occurences
            bom.CopyTo(buffer);
            actualLength = bom.Length + stream.Read(buffer.Slice(bom.Length));
            var occurrences = 0;
            do
            {
                var index = 0;
                var endIndex = actualLength - searchBytes.Length;
                for (; index <= endIndex; index++)
                    if (buffer.Slice(index, searchBytes.Length).SequenceEqual(searchBytes))
                        occurrences++;
                if (actualLength < buffer.Length)
                    break;
                ReadOnlySpan<byte> leftover = buffer.Slice(index);
                leftover.CopyTo(buffer);
                actualLength = leftover.Length + stream.Read(buffer.Slice(leftover.Length));
            }
            while (true);
            return occurrences;
        }
        finally { ArrayPool<byte>.Shared.Return(bufferArray); }
    }
