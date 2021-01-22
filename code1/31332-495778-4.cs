    [Flags]
    enum MyOptions {
       UpperCase = 1,
       Reverse   = 2,
       Trim      = 4
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
