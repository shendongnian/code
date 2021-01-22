    private string specialCharacters = "";
    public string SpecialCharacters
    {
       get { if ( usingDecimals ) 
               specialCharacters = "";
    
            return specialCharacters; }
    
       set { if( usingDecimals )
                value = "";
            
             specialCharacters = value; }
    }
    
    private boolean usingDecimals = false;
    public boolean UsingDecimals
    {  get { return usingDecimals; } 
       set { usingDecimals = value;
             if( usingDecimals )
                 specialCharacters = ""; }
    }
