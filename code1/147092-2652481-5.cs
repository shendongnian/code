    using System.Diagnostics;
    ...
    var st = new StackTrace();
    var sf = st.GetFrame(0);
    var currentMethodName = sf.GetMethod();
