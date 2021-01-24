    internal static void SetTreeNodeState(IntPtr treeViewHandle, IntPtr treeViewItemHandle, bool state)
    {
        TVITEM tvItem = new TVITEM
        {
            mask = TVIF_STATE | TVIF_HANDLE,
            hItem = treeViewItemHandle,
            stateMask = TVIS_STATEIMAGEMASK,
            state = (uint)(state ? 2 : 1) << 12
        };
        Process process = Process.GetProcessesByName("ProcessName")[0];
        IntPtr ptr = SendMessage(process, treeViewHandle, TVM_SETITEMW, 0, ref tvItem);
    }
