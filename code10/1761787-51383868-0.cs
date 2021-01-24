    public void SearchGame(string text)
    {
        try
        {
            if (!string.IsNullOrEmpty(text) && text != "")
            {                    
                var listofvalues = list1.Where(x => x.name.ToLower().StartsWith(text.ToLower(), StringComparison.CurrentCulture)).ToList();
                if (listofvalues.Count > 0)
                {                       
                    foreach (var value in listofvalues)
                    {                           
                        //loading 
                    }
                }
                else
                {
                    //No search result
                }
            }
            else
            {
               //stuff                   
            }
        }
        catch (Exception exception)
        {
            LoggingManager.Error(exception);
        }
    }
