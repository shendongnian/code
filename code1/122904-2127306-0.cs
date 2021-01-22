    // het a hex and return char (you can give it a large string or a single hexcode
    // (hex without U just HexCode)
    public static char ConvertHexToUnicode(string hexCode)
        {
            if (hexCode != string.Empty)
                return ((char)int.Parse(hexCode, NumberStyles.AllowHexSpecifier));
            
            char empty = new char();
            return empty;
        }//end
