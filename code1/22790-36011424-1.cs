    public void InstallWinService(string winServicePath)
    {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { winServicePath});
            }
            catch (Exception)
            {
                throw;
            }
    }
