    public static Type GetCallerType(Type baseClass, int skipFrames)
    {
        StackTrace trace = new StackTrace(skipFrames + 1, false);
        Type callerType = null;
    
        for (int i = 0; i < trace.FrameCount; ++i)
        {
            StackFrame frame = trace.GetFrame(i);
            Type type = frame.GetMethod().DeclaringType;
   
            if (type == baseClass || IsInheritFrom(type, baseClass))
            {
                callerType = type;
            }
            else
            {
                break;
            }
         }
         if (callerType != baseClass)
            return callerType;
         else
            return null;
    }
