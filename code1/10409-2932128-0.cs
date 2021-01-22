    /// <summary>
    /// Returns the call that occurred just before the "GetCallingMethod".
    /// </summary>
    public static string GetCallingMethod()
    {
       return GetCallingMethod("GetCallingMethod");
    }
    
    /// <summary>
    /// Returns the call that occurred just before the the method specified.
    /// </summary>
    /// <param name="MethodAfter">The named method to see what happened just before it was called. (case sensitive)</param>
    /// <returns>The method name.</returns>
    public static string GetCallingMethod(string MethodAfter)
    {
       string str = "";
       try
       {
          StackTrace st = new StackTrace();
          StackFrame[] frames = st.GetFrames();
          for (int i = 0; i < st.FrameCount - 1; i++)
          {
             if (frames[i].GetMethod().Name.Equals(MethodAfter))
             {
                if (!frames[i + 1].GetMethod().Name.Equals(MethodAfter)) // ignores overloaded methods.
                {
                   str = frames[i + 1].GetMethod().ReflectedType.FullName + "." + frames[i + 1].GetMethod().Name;
                   break;
                }
             }
          }
       }
       catch (Exception) { ; }
       return str;
    }
