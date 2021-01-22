                var st = new StackTrace(e, true);
    
                // Get the bottom stack frame
                var frame = st.GetFrame(st.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                var method = frame.GetMethod().ReflectedType.FullName;
                var path = frame.GetFileName();
