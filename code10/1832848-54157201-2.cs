    private bool CRC(string input)
    {
        if (input.Length % 2 != 0) throw new InvalidOperationException(input);
        int result = -1;
        if (int.TryParse(input.Substring(input.Length - 2), NumberStyles.HexNumber, null, out int CRC)) {
            for (int i = 0; i < input.Length - 2; i += 2) 
            {
                if (int.TryParse(input.Substring(i, 2), NumberStyles.HexNumber, null, out int value)) { 
                    result ^= value;
                } else { throw new InvalidDataException(input); }
            }
        }
        else { throw new InvalidDataException(input); }
        return result == CRC;
    }
