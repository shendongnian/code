       using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Runtime.InteropServices;
        using System.Security.AccessControl;
        using System.Security.Principal;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
    
    namespace Hide2
    {
        public partial class Form1 : Form
        {
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool GetKernelObjectSecurity(IntPtr Handle, int securityInformation, [Out] byte[] pSecurityDescriptor,
            uint nLength, out uint lpnLengthNeeded);
    
            public static RawSecurityDescriptor GetProcessSecurityDescriptor(IntPtr processHandle)
            {
                const int DACL_SECURITY_INFORMATION = 0x00000004;
                byte[] psd = new byte[0];
                uint bufSizeNeeded;
                // Call with 0 size to obtain the actual size needed in bufSizeNeeded
                GetKernelObjectSecurity(processHandle, DACL_SECURITY_INFORMATION, psd, 0, out bufSizeNeeded);
                if (bufSizeNeeded < 0 || bufSizeNeeded > short.MaxValue)
                    throw new Win32Exception();
                // Allocate the required bytes and obtain the DACL
                if (!GetKernelObjectSecurity(processHandle, DACL_SECURITY_INFORMATION,
                psd = new byte[bufSizeNeeded], bufSizeNeeded, out bufSizeNeeded))
                    throw new Win32Exception();
                // Use the RawSecurityDescriptor class from System.Security.AccessControl to parse the bytes:
                return new RawSecurityDescriptor(psd, 0);
            }
    
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern bool SetKernelObjectSecurity(IntPtr Handle, int securityInformation, [In] byte[] pSecurityDescriptor);
    
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetCurrentProcess();
    
            [Flags]
            public enum ProcessAccessRights
            {
                PROCESS_CREATE_PROCESS = 0x0080, //  Required to create a process.
                PROCESS_CREATE_THREAD = 0x0002, //  Required to create a thread.
                PROCESS_DUP_HANDLE = 0x0040, // Required to duplicate a handle using DuplicateHandle.
                PROCESS_QUERY_INFORMATION = 0x0400, //  Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken, GetExitCodeProcess, GetPriorityClass, and IsProcessInJob).
                PROCESS_QUERY_LIMITED_INFORMATION = 0x1000, //  Required to retrieve certain information about a process (see QueryFullProcessImageName). A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted PROCESS_QUERY_LIMITED_INFORMATION. Windows Server 2003 and Windows XP/2000:  This access right is not supported.
                PROCESS_SET_INFORMATION = 0x0200, //    Required to set certain information about a process, such as its priority class (see SetPriorityClass).
                PROCESS_SET_QUOTA = 0x0100, //  Required to set memory limits using SetProcessWorkingSetSize.
                PROCESS_SUSPEND_RESUME = 0x0800, // Required to suspend or resume a process.
                PROCESS_TERMINATE = 0x0001, //  Required to terminate a process using TerminateProcess.
                PROCESS_VM_OPERATION = 0x0008, //   Required to perform an operation on the address space of a process (see VirtualProtectEx and WriteProcessMemory).
                PROCESS_VM_READ = 0x0010, //    Required to read memory in a process using ReadProcessMemory.
                PROCESS_VM_WRITE = 0x0020, //   Required to write to memory in a process using WriteProcessMemory.
                DELETE = 0x00010000, // Required to delete the object.
                READ_CONTROL = 0x00020000, //   Required to read information in the security descriptor for the object, not including the information in the SACL. To read or write the SACL, you must request the ACCESS_SYSTEM_SECURITY access right. For more information, see SACL Access Right.
                SYNCHRONIZE = 0x00100000, //    The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state.
                WRITE_DAC = 0x00040000, //  Required to modify the DACL in the security descriptor for the object.
                WRITE_OWNER = 0x00080000, //    Required to change the owner in the security descriptor for the object.
                STANDARD_RIGHTS_REQUIRED = 0x000f0000,
                PROCESS_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF),//    All possible access rights for a process object.
            }
            public static void SetProcessSecurityDescriptor(IntPtr processHandle, RawSecurityDescriptor dacl)
            {
                const int DACL_SECURITY_INFORMATION = 0x00000004;
                byte[] rawsd = new byte[dacl.BinaryLength];
                dacl.GetBinaryForm(rawsd, 0);
                if (!SetKernelObjectSecurity(processHandle, DACL_SECURITY_INFORMATION, rawsd))
                    throw new Win32Exception();
            }
    
            public Form1()
            {
                InitializeComponent();
    
                // Get the current process handle
                IntPtr hProcess = GetCurrentProcess();
                // Read the DACL
                var dacl = GetProcessSecurityDescriptor(hProcess);
                // Insert the new ACE
                dacl.DiscretionaryAcl.InsertAce(
                0,
                new CommonAce(
                AceFlags.None,
                AceQualifier.AccessDenied,
                (int)ProcessAccessRights.PROCESS_ALL_ACCESS,
                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                false,
                null)
                );
                // Save the DACL
                SetProcessSecurityDescriptor(hProcess, dacl);
            }
        }
    }
