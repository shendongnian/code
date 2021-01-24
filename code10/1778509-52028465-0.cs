        Process[] pp = Process.GetProcessesByName("Game.exe");
        foreach (Process process in pp)
        {
            IntPtr handle = OpenProcess(0x1F0FFF, false, process.Id);
            int written = 0;
            // make like ths
            byte[] write = { 0x00, 0x00 };
            //MildFz is smexy
            WriteProcessMemory((int)handle, 0x00, write, write.Length, ref written);
        }
