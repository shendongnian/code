    private static bool ClearKeyboardBuffer(uint vk, uint sc, IntPtr hkl)
    {
        StringBuilder sb = new StringBuilder(10);
        int rc = -1;
        bool isDeadKey = false;
        while (rc < 0)
        {
            rc = user32.ToUnicodeEx(vk, sc, new byte[256], sb, sb.Capacity, 0, hkl);
            if (!isDeadKey && rc == -1) isDeadKey = true;
            Console.Write(rc);
        }
        return isDeadKey;
    }
