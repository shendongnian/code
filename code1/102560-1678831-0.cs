    using System.Diagnostics;
            StackTrace st = new StackTrace(true);
            for(int i =0; i< st.FrameCount; i++ )
            {
                // Note that high up the call stack, there is only
                // one stack frame.
                StackFrame sf = st.GetFrame(i);
                Console.WriteLine();
                Console.WriteLine("High up the call stack, Method: {0}",
                    sf.GetMethod());
                Console.WriteLine("High up the call stack, Line Number: {0}",
                    sf.GetFileLineNumber());
            }
