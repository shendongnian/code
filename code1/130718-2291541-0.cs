    try 
    { 
    }
    catch (System.Object obj)
    {
      Type type;
    
      type = obj.GetType() ;
      if (type == CustomException || type == AnotherCustomException)
      { 
        //basically do the same thing for these 2 kinds of exception 
        LogException(); 
      } 
      else if  (type == SomeOtherException ex) 
      { 
        //Do Something else 
      }
      else
      {
        // Wasn't an exception to handle here
        throw obj;
      }
    }
