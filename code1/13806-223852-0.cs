    // string hex = "bacg123"; doesn't parse
    // string hex = "bac123"; parses
     string hex = "bacg123";
     long output;
     long.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out output);
