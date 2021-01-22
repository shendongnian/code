    string HexFromID(int ID)
    {
        return ID.ToString("X");
    }
    int IDFromHex(string HexID)
    {
        return int.Parse(HexID, System.Globalization.NumberStyles.HexNumber);
    }
