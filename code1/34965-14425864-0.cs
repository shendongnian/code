    public bool isLoggedOn()
    {
        Process[] pname = Process.GetProcessesByName("winlogon");
        if (pname.Length == 0)
            return false;
        else
            return true;
    }
