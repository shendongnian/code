    private static Assembly GetMyCallingAssembly()
    {
      Assembly me = Assembly.GetExecutingAssembly();
      StackTrace st = new StackTrace(false);
      foreach (StackFrame frame in st.GetFrames())
      {
        MethodBase m = frame.GetMethod();
        if (m != null && m.DeclaringType != null && m.DeclaringType.Assembly != me)
          return m.DeclaringType.Assembly;
      }
      return null;
    }
