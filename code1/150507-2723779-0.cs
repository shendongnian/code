    using System;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
      class Program
      {    
        static void Main(string[] args)
        {      
          try
          {
            TestFunction();
          }
          catch (Exception ex)
          {
            StackTrace st = new StackTrace(ex, true);
            StackFrame[] frames = st.GetFrames();
    
            // Iterate over the frames extracting the information you need
            foreach (StackFrame frame in frames)
            {
              Console.WriteLine("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
            }
          }
          
          Console.ReadKey();
        }
    
        static void TestFunction()
        {      
          throw new InvalidOperationException();
        }
      }
    }
