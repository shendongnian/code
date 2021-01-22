    qualchap = ConvertFillAndSet(Request.Querystring["qchap"]);
    genchap = ConvertFillAndSet(Request.QueryString["gchap"]);
    
    private int ConvertFillAndSet(string qrystring)
    {
      int numberToReturn = 0;
      bool result;
      result = Int32.TryParse(qrystring,numberToReturn);
      
      //if result == true, then the conversion was ok
      if (result)
      {
        FillQualityList();
        SetChapterTitle();
      }
    
      //returns 0 if tryparse didn't work
      return numberToReturn;
    }
