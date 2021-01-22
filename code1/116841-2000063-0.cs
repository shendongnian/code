    public static char ConvertHexToUnicode(string hexCode)
        {
            if (hexCode != string.Empty)
                return ((char)int.Parse(hexCode, NumberStyles.AllowHexSpecifier));
            
            char empty = new char();
            return empty;
        }//end
