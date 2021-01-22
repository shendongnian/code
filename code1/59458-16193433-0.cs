    /// <summary>
    /// Determines whether the local machine is a member of a domain.
    /// </summary>
    /// <returns>A boolean value that indicated whether the local machine is a member of a domain.</returns>
    /// <remarks>http://msdn.microsoft.com/en-us/library/windows/desktop/aa394102%28v=vs.85%29.aspx</remarks>
    public bool IsDomainMember()
    {
        ManagementObject ComputerSystem;
        using (ComputerSystem = new ManagementObject(String.Format("Win32_ComputerSystem.Name='{0}'", Environment.MachineName)))
        {
            ComputerSystem.Get();
            object Result = ComputerSystem["PartOfDomain"];
            return (Result != null && (bool)Result);
        }
    }   
