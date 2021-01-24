      try
      {
          if (array != null && array.Length != 0)
          {
             int c = array.Count();
             string Open = array[0].ToString(); <--- ERROR
          }
      }
      catch(Exception ex)
      {
          // Put breakpoint here and see inner exception by hovering your mouse cursor over ex.
      }
