    static public string ConvertFromBytes(byte[] input)
    {
        StringBuilder output = new StringBuilder(input.Length);
        foreach (byte b in input)
        {
            // Printable chars are from 0x20 (space) to 0x7E (~)
            if (b >= 0x20 && b <= 0x7E)
            {
                output.Append((char)b);
            }
            else
            {
                // This isn't a text char, so use a placehold char instead
                output.Append(".");
            }
        }
        return output.ToString();
    }
