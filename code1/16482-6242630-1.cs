        private static unsafe bool GetTBButton(IntPtr hToolbar, int i, ref TBBUTTON tbButton, ref string text, ref IntPtr ipWindowHandle)
        {
            // One page
            const int BUFFER_SIZE = 0x1000;
            byte[] localBuffer = new byte[BUFFER_SIZE];
            UInt32 processId = 0;
            UInt32 threadId = User32.GetWindowThreadProcessId(hToolbar, out processId);
            IntPtr hProcess = Kernel32.OpenProcess(ProcessRights.ALL_ACCESS, false, processId);
            if (hProcess == IntPtr.Zero) { Debug.Assert(false); return false; }
            IntPtr ipRemoteBuffer = Kernel32.VirtualAllocEx(
                hProcess,
                IntPtr.Zero,
                new UIntPtr(BUFFER_SIZE),
                MemAllocationType.COMMIT,
                MemoryProtection.PAGE_READWRITE);
            if (ipRemoteBuffer == IntPtr.Zero) { Debug.Assert(false); return false; }
            // TBButton
            fixed (TBBUTTON* pTBButton = &tbButton)
            {
                IntPtr ipTBButton = new IntPtr(pTBButton);
                int b = (int)User32.SendMessage(hToolbar, TB.GETBUTTON, (IntPtr)i, ipRemoteBuffer);
                if (b == 0) { Debug.Assert(false); return false; }
                // this is fixed
                Int32 dwBytesRead = 0;
                IntPtr ipBytesRead = new IntPtr(&dwBytesRead);
                bool b2 = Kernel32.ReadProcessMemory(
                    hProcess,
                    ipRemoteBuffer,
                    ipTBButton,
                    new UIntPtr((uint)sizeof(TBBUTTON)),
                    ipBytesRead);
                if (!b2) { Debug.Assert(false); return false; }
            }
            // button text
            fixed (byte* pLocalBuffer = localBuffer)
            {
                IntPtr ipLocalBuffer = new IntPtr(pLocalBuffer);
                int chars = (int)User32.SendMessage(hToolbar, TB.GETBUTTONTEXTW, (IntPtr)tbButton.idCommand, ipRemoteBuffer);
                if (chars == -1) { Debug.Assert(false); return false; }
                // this is fixed
                Int32 dwBytesRead = 0;
                IntPtr ipBytesRead = new IntPtr(&dwBytesRead);
                bool b4 = Kernel32.ReadProcessMemory(
                    hProcess,
                    ipRemoteBuffer,
                    ipLocalBuffer,
                    new UIntPtr(BUFFER_SIZE),
                    ipBytesRead);
                if (!b4) { Debug.Assert(false); return false; }
                text = Marshal.PtrToStringUni(ipLocalBuffer, chars);
                if (text == " ") text = String.Empty;
            }
