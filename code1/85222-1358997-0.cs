    // In DLL
    public static class ApplicationStarter
    {
         public static void Main()
         {
              // Add logic here.
         }
    }
    // In program:
    {
         [STAThread]
         public static void Main()
         {
              ApplicationStarter.Main();
         }
    }
