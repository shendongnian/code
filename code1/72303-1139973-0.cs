    string HexFromID(int ID)
    {
        return ID.ToString("X");
    }
    int IDFromHex(string HexID)
    {
        return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
    }
