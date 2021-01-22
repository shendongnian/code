    public static bool IsNumber(Keys key)
    {
      string num = key.ToString().Substring(key.ToString().Length - 1);
      Int64 i64;
      if (Int64.TryParse(num, out i64))
      {
        return true;               
      }
      return false;
    }
