    public static bool StartsWith(this byte[] thisArray, byte[] otherArray)
    {
       // Handle invalid/unexpected input
       // (nulls, thisArray.Length < otherArray.Length, etc.)
       for (int i = 0; i < otherArray.Length; ++i)
       {
           if (thisArray[i] != otherArray[i])
           {
               return false;
           }
       }
       return true;
    }
