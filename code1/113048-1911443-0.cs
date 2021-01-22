    public class ProcessSecurity : NativeObjectSecurity
    {
        public ProcessSecurity(SafeHandle processHandle)
            : base(false, ResourceType.KernelObject, processHandle, AccessControlSections.Access)
        {
        }
        public void AddAccessRule(ProcessAccessRule rule)
        {
            base.AddAccessRule(rule);
        }
        public override Type AccessRightType
        {
            get { return typeof(ProcessAccessRights); }
        }
        public override AccessRule AccessRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
        {
            return new ProcessAccessRule(identityReference, (ProcessAccessRights)accessMask, isInherited, inheritanceFlags, propagationFlags, type);
        }
        public override Type AccessRuleType
        {
            get { return typeof(ProcessAccessRule); }
        }
        public override AuditRule AuditRuleFactory(System.Security.Principal.IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags)
        {
            throw new NotImplementedException();
        }
        public override Type AuditRuleType
        {
            get { throw new NotImplementedException(); }
        }
    }
    public class ProcessAccessRule : AccessRule
    {
        public ProcessAccessRule(IdentityReference identityReference, ProcessAccessRights accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type)
            : base(identityReference, (int)accessMask, isInherited, inheritanceFlags, propagationFlags, type)
        {
        }
        public ProcessAccessRights ProcessAccessRights { get { return (ProcessAccessRights)AccessMask; } }
    }
    [Flags]
    public enum ProcessAccessRights
    {
        STANDARD_RIGHTS_REQUIRED = (0x000F0000),
        DELETE = (0x00010000), // Required to delete the object. 
        READ_CONTROL = (0x00020000), // Required to read information in the security descriptor for the object, not including the information in the SACL. To read or write the SACL, you must request the ACCESS_SYSTEM_SECURITY access right. For more information, see SACL Access Right. 
        WRITE_DAC = (0x00040000), // Required to modify the DACL in the security descriptor for the object. 
        WRITE_OWNER = (0x00080000), // Required to change the owner in the security descriptor for the object. 
        PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF, //All possible access rights for a process object.
        PROCESS_CREATE_PROCESS = (0x0080), // Required to create a process. 
        PROCESS_CREATE_THREAD = (0x0002), // Required to create a thread. 
        PROCESS_DUP_HANDLE = (0x0040), // Required to duplicate a handle using DuplicateHandle. 
        PROCESS_QUERY_INFORMATION = (0x0400), // Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken, GetExitCodeProcess, GetPriorityClass, and IsProcessInJob). 
        PROCESS_QUERY_LIMITED_INFORMATION = (0x1000),
        PROCESS_SET_INFORMATION = (0x0200), // Required to set certain information about a process, such as its priority class (see SetPriorityClass). 
        PROCESS_SET_QUOTA = (0x0100), // Required to set memory limits using SetProcessWorkingSetSize. 
        PROCESS_SUSPEND_RESUME = (0x0800), // Required to suspend or resume a process. 
        PROCESS_TERMINATE = (0x0001), // Required to terminate a process using TerminateProcess. 
        PROCESS_VM_OPERATION = (0x0008), // Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory). 
        PROCESS_VM_READ = (0x0010), // Required to read memory in a process using ReadProcessMemory. 
        PROCESS_VM_WRITE = (0x0020), // Required to write to memory in a process using WriteProcessMemory. 
        SYNCHRONIZE = (0x00100000), // Required to wait for the process to terminate using the wait functions. 
    }
