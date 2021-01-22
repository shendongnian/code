    [Conditional("DEBUG")]
    public static void DebugAssertValueEquality<T>(T current, T other, bool expected, 
                                                   params string[] ignoredFields) {
        if (null == current) 
        { throw new ArgumentNullException("current"); }
        if (null == ignoredFields)
        { ignoredFields = new string[] { }; }
    
        FieldInfo lastField = null;
        bool test;
        if (object.ReferenceEquals(other, null))
        { Debug.Assert(false == expected, "The other object was null"); return; }
        test = true;
        foreach (FieldInfo fi in current.GetType().GetFields(BindingFlags.Instance)) {
            if (test = false) { break; }
            if (0 <= Array.IndexOf<string>(ignoredFields, fi.Name))
            { continue; }
            lastField = fi;
            object leftValue = fi.GetValue(current);
            object rightValue = fi.GetValue(other);
            if (object.ReferenceEquals(null, leftValue)) {
                if (!object.ReferenceEquals(null, rightValue))
                { test = false; }
            }
            else if (object.ReferenceEquals(null, rightValue))
            { test = false; }
            else {
                if (!leftValue.Equals(rightValue))
                { test = false; }
            }
        }
        Debug.Assert(test == expected, string.Format("field: {0}", lastField));
    }
