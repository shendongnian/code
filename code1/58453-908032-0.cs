    public bool isStringValid(string input) {
      if ( null == input ) { 
        throw new ArgumentNullException("input");
      }
      return System.Text.RegularExpressions.Regex.IsMatch(input, "^[A-Za-z0-9\-]*$");
    }
