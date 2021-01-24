    var text = "Username:King100 ID:100 Level:10";
    /* 
       Splits the given string on spaces and then splits on ":"
       and creates a Dictionary ("Dictionary<TKey, TValue>")
    */
    var dict = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(part => part.Split(':'))
                   .ToDictionary(split => split[0], split => split[1]);
    //If the dictionary count is greater than Zero
    if(dict.Count > 0)
    {
      var levelValue = dict["Level"].ToString();
    }    
