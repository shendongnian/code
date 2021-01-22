    private static void Main (string[] args)
    {
      CEnumResult oEnumResult = CEnumResultClassCommon.Error_Initialization;
      string sName = oEnumResult.Name;   // sName = "Error_Initialization"
      CEnum[] aoEnumResult = CEnumResultClassCommon.GetValues ();   // aoEnumResult = {testCEnumResult.Program.CEnumResult[9]}
      string[] asEnumNames = CEnum.GetNames (aoEnumResult);
      int ixValue = Array.IndexOf (aoEnumResult, oEnumResult);    // ixValue = 6
    }
