    public SCardError ListReaders(IntPtr hContext, string[] groups, out string[] readers) {
        var dwReaders = 0;
        // initialize groups array
        byte[] mszGroups = null;
        if (groups != null)
        mszGroups = SCardHelper.ConvertToByteArray(groups, TextEncoding);            
        // determine the needed buffer size
        var rc = SCardHelper.ToSCardError(
            SCardListReaders(hContext,
            mszGroups,
            null,
            ref dwReaders));
        if (rc != SCardError.Success) {
            readers = null;
            return rc;
        }
        //doubling buffer size to work through thin clients
        dwReaders *= 2; // <------------------ New line
        // initialize array
        var mszReaders = new byte[dwReaders * sizeof(char)];
        rc = SCardHelper.ToSCardError(
            SCardListReaders(hContext,
            mszGroups,
            mszReaders,
            ref dwReaders));
        readers = (rc == SCardError.Success)
                  ? SCardHelper.ConvertToStringArray(mszReaders, TextEncoding)
                  : null;
        return rc;
    }
