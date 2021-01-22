    public boolean IsNumber(String value) {
      Boolean value = true;
      foreach(Char c in s.ToCharArray()) {
        value = value && Char.IsDigit(c);
      }
    
      return value;
    }
