    private static void DoWork()
    {
        Example ex = new Example();
        byte[] res = ex.Hash; // [1]
        // If the finalizer runs before the call to the Hash 
        // property completes, the hashValue array might be
        // cleared before the property value is read. The 
        // following test detects that.
        if (res[0] != 2) // NOTE
        {
            // Oops... The finalizer of ex was launched before
            // the Hash method/property completed
        }
      GC.SuppressFinalize(ex); // keep our instance alive in case we need it.. uh.. we don't
    }
