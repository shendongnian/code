    var columns = from c in factory.GetColumnNames("eventNames")
                              where CharactersAfterFirstAreInteger(c)
                              select c;
    private bool CharactersAfterFirstAreInteger(string stringToCheck)
    {
      var subString = stringToCheck.SubString(1);
      int result = 0;
      
      return int.TryParse(subString, out result);
    }
