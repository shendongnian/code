    public static bool IsStoreAvailable()
    {
        using (var shell = PowerShell.Create())
        {
            shell.AddScript("Get-AppxPackage -Name Microsoft.StorePurchaseApp");
            var result = shell.Invoke();
            return result.Any();
        }
    }
