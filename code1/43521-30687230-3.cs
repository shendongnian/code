    public static void GrantAccessToWindowStationAndDesktop(string username)
    {
        const int WindowStationAllAccess = 0x000f037f;
        GrantAccess(username, GetProcessWindowStation(), WindowStationAllAccess);
        const int DesktopRightsAllAccess = 0x000f01ff;
        GrantAccess(username, GetThreadDesktop(GetCurrentThreadId()), DesktopRightsAllAccess);
    }
    private static void GrantAccess(string username, IntPtr handle, int accessMask)
    {
        SafeHandle safeHandle = new NoopSafeHandle(handle);
        GenericSecurity security =
            new GenericSecurity(
                false, ResourceType.WindowObject, safeHandle, AccessControlSections.Access);
        security.AddAccessRule(
            new GenericAccessRule(
                new NTAccount(username), accessMask, AccessControlType.Allow));
        security.Persist(safeHandle, AccessControlSections.Access);
    }
    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetProcessWindowStation();
    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetThreadDesktop(int dwThreadId);
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern int GetCurrentThreadId();
    // All the code to manipulate a security object is available in .NET framework,
    // but its API tries to be type-safe and handle-safe, enforcing a special implementation
    // (to an otherwise generic WinAPI) for each handle type. This is to make sure
    // only a correct set of permissions can be set for corresponding object types and
    // mainly that handles do not leak.
    // Hence the AccessRule and the NativeObjectSecurity classes are abstract.
    // This is the simplest possible implementation that yet allows us to make use
    // of the existing .NET implementation, sparing necessity to
    // P/Invoke the underlying WinAPI.
    private class GenericAccessRule : AccessRule
    {
        public GenericAccessRule(
            IdentityReference identity, int accessMask, AccessControlType type) :
            base(identity, accessMask, false, InheritanceFlags.None,
                 PropagationFlags.None, type)
        {
        }
    }
    private class GenericSecurity : NativeObjectSecurity
    {
        public GenericSecurity(
            bool isContainer, ResourceType resType, SafeHandle objectHandle,
            AccessControlSections sectionsRequested)
            : base(isContainer, resType, objectHandle, sectionsRequested)
        {
        }
        new public void Persist(SafeHandle handle, AccessControlSections includeSections)
        {
            base.Persist(handle, includeSections);
        }
        new public void AddAccessRule(AccessRule rule)
        {
            base.AddAccessRule(rule);
        }
        #region NativeObjectSecurity Abstract Method Overrides
        public override Type AccessRightType
        {
            get { throw new NotImplementedException(); }
        }
        public override AccessRule AccessRuleFactory(
            System.Security.Principal.IdentityReference identityReference, 
            int accessMask, bool isInherited, InheritanceFlags inheritanceFlags,
            PropagationFlags propagationFlags, AccessControlType type)
        {
            throw new NotImplementedException();
        }
        public override Type AccessRuleType
        {
            get { return typeof(AccessRule); }
        }
        public override AuditRule AuditRuleFactory(
            System.Security.Principal.IdentityReference identityReference, int accessMask,
            bool isInherited, InheritanceFlags inheritanceFlags,
            PropagationFlags propagationFlags, AuditFlags flags)
        {
            throw new NotImplementedException();
        }
        public override Type AuditRuleType
        {
            get { return typeof(AuditRule); }
        }
        #endregion
    }
    // Handles returned by GetProcessWindowStation and GetThreadDesktop should not be closed
    private class NoopSafeHandle : SafeHandle
    {
        public NoopSafeHandle(IntPtr handle) :
            base(handle, false)
        {
        }
        public override bool IsInvalid
        {
            get { return false; }
        }
        protected override bool ReleaseHandle()
        {
            return true;
        }
    }
