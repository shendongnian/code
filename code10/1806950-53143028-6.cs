    public static ulong[] CountPrintable(string stringToCount)
    {
        var counter = new ulong[95];
        foreach (var character in stringToCount)
        {
            var charValue = (int)character;
            if (charValue > 31)
            {
               counter[charValue - 32] +=1;
            }
        }
        return counter;
    }
