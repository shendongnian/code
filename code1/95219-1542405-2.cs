    public static List<SomeDTO> GetData(Guid userId, int languageId)
    {
      // Do something here
    }
    public static List<int> GetDataIds(Guid userId, int iNumberOfItems)
    {
      var result = GetData(userID, 0);
    
      return (from r in result select c.id).Take(iNumberOfItems).ToList<int>();
    }
