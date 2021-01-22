    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    //...
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetMyMethodName() {
      var st = new StackTrace(new StackFrame(1));
      return st.GetFrame(0).GetMethod().Name;
    } 
