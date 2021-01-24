    // Capitalize the method name according to c# naming conventions.
    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        // no point of checking if the string contains the values, IndexOf will return -1 if it doesn't.
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            // You don't need to specify that 0, IndexOf other overload already starts from zero.
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        // else is redundant since there is a return statement in the if.
        else
        {
            return "";
        }
    }
