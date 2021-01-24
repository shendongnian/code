    public static ulong[] Count(string stringToCount)
    {
        var counter = new ulong[127];
        foreach (var character in stringToCount)
        {
            counter[(int)character] +=1;
        }
        return counter;
    }
