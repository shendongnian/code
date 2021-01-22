    System.Diagnostics.StackTrace sTrace = new System.Diagnostics.StackTrace(true);
    for (Int32 frameCount = 0; frameCount < sTrace.FrameCount; frameCount++){ 
         System.Diagnostics.StackFrame sFrame = sTrace.GetFrame(frameCount);
         System.Reflection.MethodBase thisMethod = sFrame.GetMethod();
         if (thisMethod == currentMethod){
              if (frameCount + 1 <= sTrace.FrameCount){
                   System.Diagnostics.StackFrame prevFrame = sTrace.GetFrame(frameCount + 1);
                   System.Reflection.MethodBase prevMethod = prevFrame.GetMethod();
              }
         }
    }
