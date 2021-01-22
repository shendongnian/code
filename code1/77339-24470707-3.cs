    public static string CutToUTF8Length(string str, int byteLength)
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(str);
        string returnValue = string.Empty;
        if (byteArray.Length > byteLength)
        {
            int bytePointer = byteLength;
            // Check high bit to see if we're [potentially] in the middle of a multi-byte char
            if (bytePointer >= 0 
                && (byteArray[bytePointer] & Convert.ToByte("10000000", 2)) > 0)
            {
                // If so, keep walking back until we have a byte starting with `11`,
                // which means the first byte of a multi-byte UTF8 character.
                while (bytePointer >= 0 
                    && Convert.ToByte("11000000", 2) != (byteArray[bytePointer] & Convert.ToByte("11000000", 2)))
                {
                    bytePointer--;
                }
            }
            // See if we had 1s in the high bit all the way back. If so, we're toast. Return empty string.
            if (0 != bytePointer)
            {
                byte[] cutValue = new byte[bytePointer];
                Array.Copy(byteArray, cutValue, bytePointer);
                returnValue = Encoding.UTF8.GetString(cutValue);
            }
        }
        else
        {
            returnValue = str;
        }
        return returnValue;
    }
