    const int bufferSize = 1024;
    var bytes = new byte[bufferSize];
    // This will probably be sufficient...
    var chars = new char[bufferSize];
    var decoder = Encoding.UTF8.GetDecoder();
    // We don't know how long the result will be in chars, but one byte per char is a
    // reasonable first approximation
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
            // You might be able to remove these next five lines - I don't know
            // whether you can guarantee that there is at most one char
            // per byte
            int numChars = decoder.GetCharCount(bytes, 0, read);
            if (numChars > chars.Length)
            {
                chars = new char[numChars];
            }
            int readChars = decoder.GetChars(bytes, 0, readBytes, chars, 0);
            result.Append(chars, 0, readChars);
        }
    }
