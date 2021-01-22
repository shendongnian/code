    /// <summary>
    /// Reads a text file, and detects whether its encoding is valid UTF-8 or ascii.
    /// If not, decodes the text using the given fallback encoding.
    /// Bit-wise mechanism for detecting valid UTF-8 based on
    /// https://ianthehenry.com/2015/1/17/decoding-utf-8/
    /// </summary>
    /// <param name="docBytes">The bytes read from the file.</param>
    /// <param name="encoding">The default encoding to use as fallback if the text is detected not to be pure ascii or UTF-8 compliant. This ref parameter is changed to the detected encoding.</param>
    /// <returns>The contents of the read file, as String.</returns>
    public static String ReadFileAndGetEncoding(Byte[] docBytes, ref Encoding encoding)
    {
        if (encoding == null)
            encoding = Encoding.GetEncoding(1252);
        Int32 len = docBytes.Length;
        // byte order mark for utf-8. Easiest way of detecting encoding.
        if (len > 3 && docBytes[0] == 0xEF && docBytes[1] == 0xBB && docBytes[2] == 0xBF)
        {
            encoding = new UTF8Encoding(true);
            // Note that even when initialising an encoding to have
            // a BOM, it does not cut it off the front of the input.
            return encoding.GetString(docBytes, 3, len - 3);
        }
        Boolean isPureAscii = true;
        Boolean isUtf8Valid = true;
        for (Int32 i = 0; i < len; ++i)
        {
            Int32 skip = TestUtf8(docBytes, i);
            if (skip == 0)
                continue;
            if (isPureAscii)
                isPureAscii = false;
            if (skip < 0)
            {
                isUtf8Valid = false;
                // if invalid utf8 is detected, there's no sense in going on.
                break;
            }
            i += skip;
        }
        if (isPureAscii)
            encoding = new ASCIIEncoding(); // pure 7-bit ascii.
        else if (isUtf8Valid)
            encoding = new UTF8Encoding(false);
        // else, retain given encoding. This should be an 8-bit encoding like Windows-1252.
        return encoding.GetString(docBytes);
    }
    /// <summary>
    /// Tests if the bytes following the given offset are UTF-8 valid, and
    /// returns the amount of bytes to skip ahead to do the next read if it is.
    /// If the text is not UTF-8 valid it returns -1.
    /// </summary>
    /// <param name="binFile">Byte array to test</param>
    /// <param name="offset">Offset in the byte array to test.</param>
    /// <returns>The amount of bytes to skip ahead for the next read, or -1 if the byte sequence wasn't valid UTF-8</returns>
    public static Int32 TestUtf8(Byte[] binFile, Int32 offset)
    {
        // 7 bytes (so 6 added bytes) is the maximum the UTF-8 design could support,
        // but in reality it only goes up to 3, meaning the full amount is 4.
        const Int32 maxUtf8Length = 4;
        Byte current = binFile[offset];
        if ((current & 0x80) == 0)
            return 0; // valid 7-bit ascii. Added length is 0 bytes.
        Int32 len = binFile.Length;
        for (Int32 addedlength = 1; addedlength < maxUtf8Length; ++addedlength)
        {
            Int32 fullmask = 0x80;
            Int32 testmask = 0;
            // This code adds shifted bits to get the desired full mask.
            // If the full mask is [111]0 0000, then test mask will be [110]0 0000. Since this is
            // effectively always the previous step in the iteration I just store it each time.
            for (Int32 i = 0; i <= addedlength; ++i)
            {
                testmask = fullmask;
                fullmask += (0x80 >> (i+1));
            }
            // figure out bit masks from level
            if ((current & fullmask) == testmask)
            {
                if (offset + addedlength >= len)
                    return -1;
                // Lookahead. Pattern of any following bytes is always 10xxxxxx
                for (Int32 i = 1; i <= addedlength; ++i)
                {
                    if ((binFile[offset + i] & 0xC0) != 0x80)
                        return -1;
                }
                return addedlength;
            }
        }
        // Value is greater than the maximum allowed for utf8. Deemed invalid.
        return -1;
    }
