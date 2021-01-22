    private WindowsImpersonationContext context = null;
    public void RevertToAppPool()
    {
        try
        {
            if (!WindowsIdentity.GetCurrent().IsSystem)
            {
                context = WindowsIdentity.Impersonate(System.IntPtr.Zero);
            }
        }
        catch { }
    }
    public void UndoImpersonation()
    {
        try
        {
            if (context != null)
            {
                context.Undo();
            }
        }
        catch { }
    }
