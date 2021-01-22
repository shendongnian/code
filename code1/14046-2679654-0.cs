    static int Main(string[] args)
    {
        if (!HasAdministratorPrivileges())
        {
            Console.Error.WriteLine("Access Denied. Administrator permissions are " +
                "needed to use the selected options. Use an administrator command " +
                "prompt to complete these tasks.");
            return 740; // ERROR_ELEVATION_REQUIRED
        }
        
        ...
        return 0;
    }
    private static bool HasAdministratorPrivileges()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(id);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
