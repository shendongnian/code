    System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(1);
    System.Diagnostics.StackFrame sf = st.GetFrame(0);
    string msg = sf.GetMethod().DeclaringType.FullName + "." +
    sf.GetMethod().Name;
    MessageBox.Show( msg );
