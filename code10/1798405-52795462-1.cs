    private string _name = "";
    
    public string Name
    {
       get
       {
          return _name;
       }
       set
       {
          if ( string.IsNullOrEmpty(value) )
          {
              //throw or fallback
          }
          else
          {
              _name = value;
          }
       }
    }
