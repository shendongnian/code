    public Boolean IsNumber(String s) {
      Boolean value = true;
      foreach(Char c in s.ToCharArray()) {
        value = value && Char.IsDigit(c);
      }
    
      return value;
    }
