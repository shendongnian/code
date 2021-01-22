    Using System.Text.RegularExpression;
    
    public ArraList() GetEmployeeList(string XmlText){ 
      ArrayList lst = new ArrayList();
      RegEx regExp = new RegEx(@"\d{3}");
      MatchCollection mstLst = regExp.Matches(Xmltext);
      foreach(Match iMatch in mstLst){
          lst.Add(iMatch.Value.ToString());
      }
      
    Return lst;
    }
