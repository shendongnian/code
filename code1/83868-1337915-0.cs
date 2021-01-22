    public override int GetBytes(string chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
    {
        if ((chars == null) || (bytes == null))
        {
            throw new ArgumentNullException();
        }
        if ((charIndex < 0) || (charCount < 0))
        {
            throw new ArgumentOutOfRangeException();
        }
        if ((chars.Length - charIndex) < charCount)
        {
            throw new ArgumentOutOfRangeException();
        }
        if ((byteIndex < 0) || (byteIndex > bytes.Length))
        {
            throw new ArgumentOutOfRangeException();
        }
        if ((bytes.Length - byteIndex) < charCount)
        {
            throw new ArgumentException();
        }
        int num = charIndex + charCount;
        while (charIndex < num)
        {
            char ch = chars[charIndex++];
            if (ch >= '\x0080')
            {
                ch = '?';
            }
            bytes[byteIndex++] = (byte) ch;
        }
        return charCount;
    }
 
