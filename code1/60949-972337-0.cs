     public static int GenerateEventId()
     {
         StackTrace trace = new StackTrace();
    
         StringBuilder builder = new StringBuilder();
         builder.Append(Environment.StackTrace);
    
         foreach (StackFrame frame in trace.GetFrames())
         {
               builder.Append(frame.GetILOffset());
               builder.Append(",");
         }
    
         return builder.ToString().GetHashCode() & 0xFFFF;
     }
