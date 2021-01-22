    public int? Parse(string categoryID) 
    {
      int value;
      if (int.TryParse(categoryID, out value))
      {
        return value;
      }
      else
      {
        return null;
      }
    }
  
