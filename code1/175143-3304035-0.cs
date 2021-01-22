    public string GetText()
    {
       lock( someObject )
       {
          string sRetVal = this.sText; // sText is populated by other functions in the class.
          this.sText = null; // Suspected race condition is here.
          return sRetVal;
       }
    }    
