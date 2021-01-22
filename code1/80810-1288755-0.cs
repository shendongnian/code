    switch(param.ToString())
    {
      case "1":
      if (CheckForArgumentType<B>(param))
      {
       // Do your cast here
       param = (B)param
      }
      else
         break;
      case "2":
      if (CheckForArgumentType<B>(param))
      {
       // Do your cast here
       param = (B)param
      }
      else
         break;
      }
      .................
       private bool CheckForArgumentType<T>(object argumentObject)
        {
            return (argumentObject is T)
                 
        }
