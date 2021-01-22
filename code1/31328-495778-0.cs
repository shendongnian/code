    [Flags]
    enum MyOptions {
       UpperCase,
       Reverse,
       Trim
    }
    public static void DoTransform(MyOptions options) {
        if ((options & MyOptions.UpperCase) == MyOptions.UpperCase) {
            /* Do Upper case transform */
        }
        if ((options & MyOptions.Reverse) == MyOptions.Reverse) {
            /* Do Reverse transform */
        }
        /* etc, ... */
    }
    DoTransform(MyOptions.UpperCase | MyOptions.Reverse);
