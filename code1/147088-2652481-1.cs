    [MethodImpl(MethodImplOptions.NoInlining)]
    public string GetCurrentMethod ()
    {
        StackTrace st = new StackTrace ();
        StackFrame sf = st.GetFrame (1);
    
        return sf.GetMethod ();
    }
