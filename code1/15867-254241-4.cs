    static class ExtensionsForWPF
    {
      public static System.Windows.Forms.Screen GetScreen(this Window window)
      {
        return System.Windows.Forms.Screen.FromHandle(new WindowInteropHelper(window).Handle);
      }
    }
