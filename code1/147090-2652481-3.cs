    using System.Diagnostics;
    ...
    StackTrace st = new StackTrace ();
    StackFrame sf = st.GetFrame (0);
    MethodBase currentMethodName = sf.GetMethod ();
