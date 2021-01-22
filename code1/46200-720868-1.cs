    qualchap = ConvertFillAndSet(Request.Querystring["qchap"]);
    genchap = ConvertFillAndSet(Request.QueryString["gchap"]);
    
    private int ConvertFillAndSet(string qrystring)
    {
      int numberToReturn = 0;      
      
      //if the conversion was ok -> true, else false
      if (Int32.TryParse(qrystring,numberToReturn))
      {
        FillQualityList();
        SetChapterTitle();
      }
    
      //returns 0 if tryparse didn't work
      return numberToReturn;
    }
