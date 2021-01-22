    struct PktAck
    {
      public Int32 code;
      public IntPtr text;
    }
    
    public static void Main()
    {
      var a = new PktAck();
      a.code = 314159;
      a.text = Marshal.StringToHGlobalAnsi("foo");
      try
      {
        SomePInvokeCall(a);
      }
      finally
      {
        Marshal.FreeHGlobal(a.text);
      }
    }
