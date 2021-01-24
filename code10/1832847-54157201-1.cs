    private bool CRC(string input)
    {
        if (input.Length % 2 != 0) throw new InvalidOperationException(input);
        var CRC = int.Parse(input.Substring(input.Length - 2), NumberStyles.HexNumber);
        var result = 0;
        for (int i = 0; i < input.Length - 2; i += 2)
        {
            result ^= int.Parse(input.Substring(i, 2), NumberStyles.HexNumber);
        }
        return result == CRC;  // = 61
    }
