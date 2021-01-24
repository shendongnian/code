    public int HandleInComingCall([In] uint dwCallType, [In] IntPtr htaskCaller, [In] uint dwTickCount,
        [In, MarshalAs(UnmanagedType.LPArray)] INTERFACEINFO[] lpInterfaceInfo)
    {
        Debug("HandleInComingCall");
        return 1;
    }
    public int RetryRejectedCall([In] IntPtr htaskCallee, [In] uint dwTickCount, [In] uint dwRejectType)
    {
        int retVal = -1;
        Debug.WriteLine("RetryRejectedCall");
        if (MessageBox.Show("retry?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            retVal = 1;
        }
        return retVal;
    }
    public int MessagePending([In] IntPtr htaskCallee, [In] uint dwTickCount, [In] uint dwPendingType)
    {
        Debug("MessagePending");
        return 1;
    }
