    // string hex = "bacg123"; Doesn't parse
    // string hex = "bac123"; Parses
    string hex = "bacg123";
    long output;
    long.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out output);
