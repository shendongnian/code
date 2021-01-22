    private static string GuidToRaw(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
    
        int сharCount = bytes.Length * 2;
        char[] chars = new char[сharCount];
    
        int index = 0;
        for (int i = 0; i < сharCount; i += 2)
        {
            byte b = bytes[index++];
            chars[i] = GetHexValue((int)(b / 16));
            chars[i + 1] = GetHexValue((int)(b % 16));
        }
        return new string(chars, 0, chars.Length);
    }
    
    private static char GetHexValue(int i)
    {
        return (char)(i < 10 ? i + 48 : i + 55);
    }
