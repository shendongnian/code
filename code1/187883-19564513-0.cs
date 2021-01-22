    public static String Truncate(String input,int maxLength)
    {
       if(input.Length > maxLength)
          return input.Substring(0,maxLength);
       return input;
    }
