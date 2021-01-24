    // Original:
    int In(in int _) {
        _.ToString();
        _.GetHashCode();
        return _ >= 0 ? _ + 42 : _ - 42;
    }
    // Decompiled:
    int In([In] [IsReadOnly] ref int _) {
        int num = _;
        num.ToString();    // invoke on copy
        num = _;
        num.GetHashCode(); // invoke on second copy
        if (_ < 0)
            return _ - 42; // use original in arithmetic
        return _ + 42;
    }
