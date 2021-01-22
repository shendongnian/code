    public static string ReverseString(string s)
    {
       var toReturn = new StringBuilder();
       for (var i = s.Length - 1; i >= 0; i--)
       {
          toReturn.Append(s[i]);
          }
       return toReturn.ToString();
    }
