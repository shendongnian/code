    public static bool IsNumber(Key key )
    {
      string num = key.ToString().Substring(e.Key.ToString().Length - 1);
      Int64 i64;
      if (Int64.TryParse(num, out i64))
      {
        return true;               
      }
      
       return false;
    }
