    if(ExScore == null || ExScore.Tables[0] == null ||
      IsNullOrEmpty(ExScore.Tables[0].Rows[i]["CAT1"]) || 
      IsNullOrEmpty(ExScore.Tables[0].Rows[i]["CAT2"]) || 
      IsNullOrEmpty(ExScore.Tables[0].Rows[i]["CAT3"]) || 
      IsNullOrEmpty(ExScore.Tables[0].Rows[i]["EXAM"])
    )
    {
        //set value by default
    }
    //calcul normally
    
    public bool IsNullOrEmpty(object value)
    {
        return value == null || string.IsNullOrEmpty(value.ToString());
    }
