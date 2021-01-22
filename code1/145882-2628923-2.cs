     bool result = true;
     foreach( item in list)
     {
       try
       {
         //update DB
       }
       catch(Exception ex)
       {
          //log exception
          result = false;
       }
      return result;
     }
