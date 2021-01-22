    try 
    {
       foreach (object o in list)
       {
          foreach (object another in otherList)
          {
             // ... some stuff here
             if (condition)
             {
                throw new CustomExcpetion();
             }
          }
       }
    }
    catch (CustomException)
    {
       // log 
    }
