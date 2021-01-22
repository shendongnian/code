    public static bool IsService()
    {
        ServiceController sc = new ServiceController("MyApplication");
        return sc.Status == ServiceControllerStatus.StartPending;
    }
