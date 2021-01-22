    private DateTime intDT;
    public string DateTimeProperty
    {   
          get { return intDT.ToString(); } // Return a string   
          set 
          { 
             DateTime dt;
             if (DateTime.TryParse(value, out dt))
                 intDT = dt;
             else throw new ArgumentException(string.Format(
               "{0} cannot be converted to a DateTime.", value);           
          } 
    }
