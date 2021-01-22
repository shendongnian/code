    static class GroupTypes
    {
      public const string TheGroup = "OEM";
      public const string TheOtherGroup = "CMB";
    }
    void DoSomething(string groupType)
    {
      if(groupType == GroupTypes.TheGroup)
      {
        // Be nice
      }  
      else if (groupType == GroupTypes.TheOtherGroup)
      {
        // Continue to be nice
      }
      else
      {
        // unexpected, throw exception?
      }
    }
