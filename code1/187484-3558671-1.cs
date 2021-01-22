    if(IsChanged)
      return;
    
    if(Status == "saving")
    {
        // save      
    }
    else if(string.IsNullOrEmpty(Status))
    {
        CancelClose();    
    }
