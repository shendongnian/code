    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    
    class UnManagedInterop {
      private delegate int Callback(string text);
      private Callback mInstance;   // Ensure it doesn't get garbage collected
    
      public UnManagedInterop() {
        mInstance = new Callback(Handler);
        SetCallback(mInstance);
      }
      public void Test() {
        TestCallback();
      }
    
      private int Handler(string text) {
        // Do something...
        Console.WriteLine(text);
        return 42;
      }
      [DllImport("cpptemp1.dll")]
      private static extern void SetCallback(Callback fn);
      [DllImport("cpptemp1.dll")]
      private static extern void TestCallback();
    }
