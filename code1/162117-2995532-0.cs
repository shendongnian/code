    public int Id
    {
      get { ... }
      set 
      { 
          if (!IsNumer(value)) // changes to if (value>5)
          {
                //the code here will never be executed
               id = value;
          }
      }
    }
