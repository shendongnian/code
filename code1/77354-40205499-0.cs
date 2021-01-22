    public string LimitToUTF8ByteLength(string text, int size)
    {
        if (size <= 0)
        {
            return string.Empty;
        }
    
        int maxLength = text.Length;
        int minLength = 0;
        int length = maxLength;
    
        while (maxLength >= minLength)
        {
            length = (maxLength + minLength) / 2;
            int byteLength = Encoding.UTF8.GetByteCount(text.Substring(0, length));
    
            if (byteLength > size)
            {
                maxLength = length - 1;
            }
            else if (byteLength < size)
            {
                minLength = length + 1;
            }
            else
            {
                return text.Substring(0, length); 
            }
        }
    
        // Round down the result
        string result = text.Substring(0, length);
        if (size >= Encoding.UTF8.GetByteCount(result))
        {
            return result;
        }
        else
        {
            return text.Substring(0, length - 1);
        }
    }
