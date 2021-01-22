    class TestDll
    {
      //import your tested DLL here
      [DllImport("kernel32")]     
      public extern static int LoadLibrary(string lpLibFileName);     
    }
    
    try
    {
      TestDll test = new TestDll();
    }
    catch(DllNotFoundException ex)
    {
      return false;
    }
