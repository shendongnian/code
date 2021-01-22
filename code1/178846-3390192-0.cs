    // Gets the length of this string
    //
    /// This is a EE implemented function so that the JIT can recognise is specially
    /// and eliminate checks on character fetchs in a loop like:
    /// for(int I = 0; I < str.Length; i++) str[i]
    /// The actually code generated for this will be one instruction and will be inlined.
    //
    public extern int Length {
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        get;
    }
