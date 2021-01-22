    [AssemblyInitialize()]
    public static void AssemblyInit(TestContext context)
    {
      ...
      string strRelocatedTestCaseFile =
        Path.Combine(TheToolBox.ShortPath(AppDomain.CurrentDomain.BaseDirectory),                                                                        
                     "TestCase.xml");
      if(!string.IsNullOrEmpty(strTestCaseFile)) 
      {
        string strMessage = "Copying TestCase input file: '" + 
                            strTestCaseFile + "' to '" + strRelocatedTestCaseFile + "'";
        Console.WriteLine(strMessage);
        File.Copy(strTestCaseFile, strRelocatedTestCaseFile, true);
      }
    }
