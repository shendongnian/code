    /// <summary>
    ///     Detects whether the encoding of the data is valid UTF-8 or ascii. If detection fails, the text is decoded using the given fallback encoding.
    ///     Bit-wise mechanism for detecting valid UTF-8 based on https://ianthehenry.com/2015/1/17/decoding-utf-8/
    ///     Note that pure ascii detection should not be trusted: it might mean the file is meant to be UTF-8 or Windows-1252 but simply contains no special characters.
    /// </summary>
    /// <param name="docBytes">The bytes of the text document.</param>
    /// <param name="encoding">The default encoding to use as fallback if the text is detected not to be pure ascii or UTF-8 compliant. This ref parameter is changed to the detected encoding, or Windows-1252 if the given encoding parameter is null and the text is not valid UTF-8.</param>
    /// <returns>The contents of the read file</returns>
    public static String ReadFileAndGetEncoding(Byte[] docBytes, ref Encoding encoding)
    {
        if (encoding == null)
            encoding = Encoding.GetEncoding(1252);
        // BOM detection is not added in this example. Add it yourself if you feel like it. Should set the "encoding" param and return the decoded string.
        //String file = DetectByBOM(docBytes, ref encoding);
        //if (file != null)
        //    return file;
        Boolean isPureAscii = true;
        Boolean isUtf8Valid = true;
        for (Int32 i = 0; i < docBytes.Length; i++)
        {
            Int32 skip = TestUtf8(docBytes, i);
            if (skip != 0)
            {
                if (isPureAscii)
                    isPureAscii = false;
                if (skip < 0)
                    isUtf8Valid = false;
                else
                    i += skip;
            }
            // if already detected that it's not valid utf8, there's no sense in going on.
            if (!isUtf8Valid)
                break;
        }
        if (isPureAscii)
            encoding = new ASCIIEncoding(); // pure 7-bit ascii.
        else if (isUtf8Valid)
            encoding = new UTF8Encoding(false);
        // else, retain given fallback encoding.
        return encoding.GetString(docBytes);
    }
    /// <summary>
    /// Tests if the bytes following the given offset are UTF-8 valid, and returns
    /// the extra amount of bytes to skip ahead to do the next read if it is
    /// (meaning, detecting a single-byte ascii character would return 0).
    /// If the text is not UTF-8 valid it returns -1.
    /// </summary>
    /// <param name="binFile">Byte array to test</param>
    /// <param name="offset">Offset in the byte array to test.</param>
    /// <returns>The amount of extra bytes to skip ahead for the next read, or -1 if the byte sequence wasn't valid UTF-8</returns>
    public static Int32 TestUtf8(Byte[] binFile, Int32 offset)
    {
        Byte current = binFile[offset];
        if ((current & 0x80) == 0)
            return 0; // valid 7-bit ascii. Added length is 0 bytes.
        else
        {
            Int32 len = binFile.Length;
            Int32 fullmask = 0xC0;
            Int32 testmask = 0;
            for (Int32 addedlength = 1; addedlength < 6; addedlength++)
            {
                // This code adds shifted bits to get the desired full mask.
                // If the full mask is [111]0 0000, then test mask will be [110]0 0000. Since this is
                // effectively always the previous step in the iteration I just store it each time.
                testmask = fullmask;
                fullmask += (0x40 >> addedlength);
                // Test bit mask for this level
                if ((current & fullmask) == testmask)
                {
                    // End of file. Might be cut off, but either way, deemed invalid.
                    if (offset + addedlength >= len)
                        return -1;
                    else
                    {
                        // Lookahead. Pattern of any following bytes is always 10xxxxxx
                        for (Int32 i = 1; i <= addedlength; i++)
                        {
                            // If it does not match the pattern for an added byte, it is deemed invalid.
                            if ((binFile[offset + i] & 0xC0) != 0x80)
                                return -1;
                        }
                        return addedlength;
                    }
                }
            }
            // Value is greater than the start of a 6-byte utf8 sequence. Deemed invalid.
            return -1;
        }
    }
