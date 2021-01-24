    public static class MyClass {
       ...
       // Since you don't use String, StringBuilder etc. 
       // CharSet = CharSet.Ansi is redundant and can be omitted
      [DllImport(@"my.dll", CallingConvention = CallingConvention.Cdecl)]
       public static extern int get_card(byte n, ref uint state);
       ...
    }
