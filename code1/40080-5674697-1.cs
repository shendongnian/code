    static class GroupTypes
    {
      public const string TheGroup = "OEM";
      public const string TheOtherGroup = "CMB";
    }
    void DoSomething(GroupTypes groupType)
    {
      if(groupType == GroupTypes.TheOtherGroup)
      {
        //Launch nuclear bomb 
      }  
    }
