    /// <summary>
    /// Determines whether the local machine is a member of a domain.
    /// </summary>
    /// <returns>A boolean value that indicated whether the local machine is a member of a domain.</returns>
    /// <remarks>http://msdn.microsoft.com/en-gb/library/windows/desktop/aa394102(v=vs.85).aspx</remarks>
    public bool IsDomainMember()
    {
        ManagementObject ComputerSystem;
        using (ComputerSystem = new ManagementObject(String.Format("Win32_ComputerSystem.Name='{0}'", Environment.MachineName)))
        {
            ComputerSystem.Get();
            UInt16 DomainRole = (UInt16)ComputerSystem["DomainRole"];
            return (DomainRole != 0 & DomainRole != 2);
        }
    }
