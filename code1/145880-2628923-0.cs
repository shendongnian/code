        int count = 0;
        foreach( item in list)
        {
    
        try
        {
         //update DB
         ++count;
        }
        catch(Exception ex)
        {
             //log exception
        }
        if(count == list.Count)
          return true;
         else return false;
      
       }
