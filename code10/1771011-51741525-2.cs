    internal static bool GetTreeNodeState( IntPtr treeViewHandle, IntPtr treeViewItemHandle)
    {
        TVITEM tvItem = new TVITEM
        {
            mask = TVIF_STATE | TVIF_HANDLE,
            hItem = treeViewItemHandle,
            stateMask = TVIS_STATEIMAGEMASK,
            state = 0
        };
        Process process = Process.GetProcessesByName("ProcessName")[0];
        IntPtr ptr = SendMessage(process, treeViewHandle, TVM_GETITEMW, 0, ref tvItem);
        if (ptr != IntPtr.Zero)
        {
            uint iState = tvItem.state >> 12;
            return iState == 2 ? true : false;
        }
        return false;
    }
