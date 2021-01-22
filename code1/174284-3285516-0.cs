    private static StringBuilder ListStack(out string sType)
    {
      StringBuilder sb = new StringBuilder();
      sType = "";
    
      StackTrace st = new StackTrace(true);
      foreach (StackFrame f in st.GetFrames())
      {
        MethodBase m = f.GetMethod();
        if (f.GetFileName() != null)
        {
          sb.AppendLine(string.Format("{0}:{1} {2}.{3}",
            f.GetFileName(), f.GetFileLineNumber(),
            m.DeclaringType.FullName, m.Name));
    
          if (!string.IsNullOrEmpty(m.DeclaringType.Name))
            sType = m.DeclaringType.Name;
        }
      }
    
      return sb;
    }
