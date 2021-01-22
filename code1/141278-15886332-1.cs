    public static bool HasSpecialCharacters(string str)
    {
      string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" +"\"";
      char[] specialCharactersArray = specialCharacters.ToCharArray();
      int index = str.IndexOfAny(specialCharactersArray);
      //index == -1 no special characters
      if (index == -1)
        return false;
      else
        return true;
    }
