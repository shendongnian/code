    public static string Right(this string sValue, int iMaxLength)
    {
      //Check if the value is valid
      if (string.IsNullOrEmpty(sValue))
      {
        //Set valid empty string as string could be null
        sValue = string.Empty;
      }
      else if (sValue.Length > iMaxLength)
      {
        //Make the string no longer than the max length
        sValue = sValue.Substring(sValue.Length - iMaxLength, iMaxLength);
      }
      //Return the string
      return sValue;
    }
