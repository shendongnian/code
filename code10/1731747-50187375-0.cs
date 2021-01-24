    string longName = "PRODUCT MANAGER OFFICE";
    string shortName = "P.M.O";
    
    public bool ValidateStrings(string longName, string shortName)
    {
      bool isValid = false;
      foreach (var character in shortName)
      {
        if (Char.IsLetter(character))
        {
          isValid = longName.Contains<char>(character);
          if (!isValid)
          {
            return false;
          }
        }
      }
    
      return isValid;
    }
