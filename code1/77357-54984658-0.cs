    public static String LimitByteLength(string input, int maxLength)
    {
        if (string.IsNullOrEmpty(input) || Encoding.UTF8.GetByteLength(input) <= maxLength)
        {
            return message;
        }
        var encoder = Encoding.UTF8.GetEncoder();
        byte[] buffer = new byte[maxLength];
        char[] messageChars = message.ToCharArray();
        encoder.Convert(
            chars: messageChars,
            charIndex: 0,
            charCount: messageChars.Length,
            bytes: buffer,
            byteIndex: 0,
            byteCount: buffer.Length,
            flush: false,
            charsUsed: out int charsUsed,
            bytesUsed: out int bytesUsed,
            completed: out bool completed);
        // I don't think we can return message.Substring(0, charsUsed)
        // as that's the number of UTF-16 chars, not the number of codepoints
        // (think about surrogate pairs). Therefore I think we need to
        // actually convert bytes back into a new string
        return Encoding.UTF8.GetString(bytes, 0, bytesUsed);
    }
