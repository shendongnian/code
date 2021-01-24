    public static string GetTreeItemText(IntPtr treeViewHwnd, IntPtr hItem)
    {
        string itemText;
        uint pid;
        GetWindowThreadProcessId(treeViewHwnd, out pid);
        IntPtr process = OpenProcess(ProcessAccessFlags.VirtualMemoryOperation | ProcessAccessFlags.VirtualMemoryRead | ProcessAccessFlags.VirtualMemoryWrite | ProcessAccessFlags.QueryInformation, false, pid);
        if (process == IntPtr.Zero)
            throw new Exception("Could not open handle to owning process of TreeView", new Win32Exception());
        try
        {
            uint tviSize = Marshal.SizeOf(typeof(TVITEM));
            uint textSize = MY_MAXLVITEMTEXT;
            bool isUnicode = IsWindowUnicode(treeViewHwnd);
            if (isUnicode)
                textSize *= 2;
            IntPtr tviPtr = VirtualAllocEx(process, IntPtr.Zero, tviSize + textSize, AllocationType.Commit, MemoryProtection.ReadWrite);
            if (tviPtr == IntPtr.Zero)
                throw new Exception("Could not allocate memory in owning process of TreeView", new Win32Exception());
            try
            {
                IntPtr textPtr = IntPtr.Add(tviPtr, tviSize);
                TVITEM tvi = new TVITEM();
                tvi.mask = TVIF_TEXT;
                tvi.hItem = hItem;
                tvi.cchTextMax = MY_MAXLVITEMTEXT;
                tvi.pszText = textPtr;
                IntPtr ptr = Marshal.AllocHGlobal(tviSize);
                try
                {
                    Marshal.StructureToPtr(tvi, ptr, false);
                    if (!WriteProcessMemory(process, tviPtr, ptr, tviSize, IntPtr.Zero))
                        throw new Exception("Could not write to memory in owning process of TreeView", new Win32Exception());
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
                if (SendMessage(treeViewHwnd, isUnicode ? TVM_GETITEMW : TVM_GETITEMA, 0, tviPtr) != 1)
                    throw new Exception("Could not get item data from TreeView");
                ptr = Marshal.AllocHGlobal(textSize);
                try
                {
                    int bytesRead;
                    if (!ReadProcessMemory(process, textPtr, ptr, textSize, out bytesRead))
                        throw new Exception("Could not read from memory in owning process of TreeView", new Win32Exception());
                    if (isUnicode)
                        itemText = Marshal.PtrToStringUni(ptr, bytesRead / 2);
                    else
                        itemText = Marshal.PtrToStringAnsi(ptr, bytesRead);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }
            finally
            {
                VirtualFreeEx(process, tviPtr, 0, FreeType.Release);
            }
        }
        finally
        {
            CloseHandle(process);
        }
        //char[] arr = itemText.ToCharArray(); //<== use this array to look at the bytes in debug mode
        return itemText;
    }
