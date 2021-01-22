    StringBuilder Result = new StringBuilder();
        string HexAlphabet = "0123456789ABCDEF";
     
        foreach (byte B in Bytes)
            {
            Result.Append(HexAlphabet[(int)(B >> 4)]);
            Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }
     
        return Result.ToString();
