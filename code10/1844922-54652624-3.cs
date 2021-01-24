    const int bufferSize = 1024;
    var bytes = new byte[bufferSize];
    var chars = new char[Encoding.UTF8.GetMaxCharCount(bufferSize)];
    var decoder = Encoding.UTF8.GetDecoder();
    // We don't know how long the result will be in chars, but one byte per char is a
    // reasonable first approximation. This will expand as necessary.
    var result = new StringBuilder(maxAllowedLimit);
    int totalReadBytes = 0;
    using (var stream = await response.Content.ReadAsStreamAsync())
    {
        while (totalReadBytes <= maxAllowedLimit)
        {
            int readBytes = await stream.ReadAsync(
                bytes,
                0,
                Math.Min(maxAllowedLimit - totalReadBytes, bytes.Length));
            // We reached the end of the stream
            if (readBytes == 0)
                break;
            totalReadBytes += readBytes;
            int readChars = decoder.GetChars(bytes, 0, readBytes, chars, 0);
            result.Append(chars, 0, readChars);
        }
    }
