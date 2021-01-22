    //File: RKAPPLET.EXE
    namespace RKAPPLET
    {
      using RKMFC;
      public static class Program
      {
        public static void Main ()
        {
          RKMFC.API.DoSomething();
        }
      }
    }
    //File: RKMFC.DLL
    namespace RKMFC
    {
      public static class API
      {
        public static void DoSomething ()
        {
          System.Windows.Forms.MessageBox.Show("MFC!")
        }
      }
    }
    
    //File: RKNET.DLL
    namespace RKNET
    {
      public static class API
      {
        public static void DoSomethingElse ()
        {
          System.Windows.Forms.MessageBox.Show("NET!")
        }
      }
    }
    namespace RKMFC
    {
      public static class API
      {
        public static void DoSomething ()
        {
          RKNET.API.DoSomethingElse()
        }
      }
    }
