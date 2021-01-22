    using System.Diagnostics;
    ....
    catch (Exception ex) {
      StackTrace st = new StackTrace(new StackFrame(true));
      StackFrame sf = st.GetFrame(0);
      Console.WriteLine(" File: {0}", sf.GetFileName());
      Console.WriteLine(" Method: {0}", sf.GetMethod().Name);
      Console.WriteLine(" Line Number: {0}", sf.GetFileLineNumber());
      Console.WriteLine(" Column Number: {0}", sf.GetFileColumnNumber());
    }
