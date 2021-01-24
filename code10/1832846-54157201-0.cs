    string input = "ff03c13d";
    int CRC = int.Parse(input.Substring(input.Length - 2), NumberStyles.HexNumber);
    int result = 0;
    for (int i = 0; i < input.Length - 2; i += 2) {
        result ^= int.Parse(input.Substring(i, 2), NumberStyles.HexNumber);
    }
    return result == CRC;  // = 61
