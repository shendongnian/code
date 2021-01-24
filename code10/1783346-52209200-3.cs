    public static class NativeMethods {
    	public static readonly IntPtr INVALID_HANDLE = new IntPtr(-1);
    
    	public const FileAttributes FILE_FLAG_BACKUP_SEMANTICS = (FileAttributes) 0x02000000;
    
    	public enum NTSTATUS : uint {
    		SUCCESS = 0x00000000,
    		NOT_IMPLEMENTED = 0xC0000002,
    		INVALID_INFO_CLASS = 0xC0000003,
    		INVALID_PARAMETER = 0xC000000D,
    		NOT_SUPPORTED = 0xC00000BB,
    	}
    
    	public enum FILE_INFORMATION_CLASS {
    		None = 0,
    		// Note: If you use the actual enum in here, remember to
    		// start the first field at 1. There is nothing at zero.
    		FileCaseSensitiveInformation = 71,
    	}
    
    	// It's called Flags in FileCaseSensitiveInformation so treat it as flags
    	[Flags]
    	public enum CASE_SENSITIVITY_FLAGS : uint {
    		CaseInsensitiveDirectory = 0x00000000,
    		CaseSensitiveDirectory = 0x00000001,
    	}
    
    	[StructLayout(LayoutKind.Sequential)]
    	public struct IO_STATUS_BLOCK {
    		[MarshalAs(UnmanagedType.U4)]
    		public NTSTATUS Status;
    		public ulong Information;
    	}
    		
    	[StructLayout(LayoutKind.Sequential)]
    	public struct FILE_CASE_SENSITIVE_INFORMATION {
    		[MarshalAs(UnmanagedType.U4)]
    		public CASE_SENSITIVITY_FLAGS Flags;
    	}
    
    	// An override, specifically made for FileCaseSensitiveInformation, no IntPtr necessary.
    	[DllImport("ntdll.dll")]
    	[return: MarshalAs(UnmanagedType.U4)]
    	public static extern NTSTATUS NtQueryInformationFile(
    		IntPtr FileHandle,
    		ref IO_STATUS_BLOCK IoStatusBlock,
    		ref FILE_CASE_SENSITIVE_INFORMATION FileInformation,
    		int Length,
    		FILE_INFORMATION_CLASS FileInformationClass);
    
    	[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    	public static extern IntPtr CreateFile(
    			[MarshalAs(UnmanagedType.LPTStr)] string filename,
    			[MarshalAs(UnmanagedType.U4)] FileAccess access,
    			[MarshalAs(UnmanagedType.U4)] FileShare share,
    			IntPtr securityAttributes, // optional SECURITY_ATTRIBUTES struct or IntPtr.Zero
    			[MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
    			[MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
    			IntPtr templateFile);
    		
    	[DllImport("kernel32.dll", SetLastError = true)]
    	[return: MarshalAs(UnmanagedType.Bool)]
    	public static extern bool CloseHandle(
    		IntPtr hObject);
    
    	public static bool IsDirectoryCaseSensitive(string directory, bool throwOnError = true) {
    		// Read access is NOT required
    		IntPtr hFile = CreateFile(directory, 0, FileShare.ReadWrite,
    									IntPtr.Zero, FileMode.Open,
    									FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);
    		if (hFile == INVALID_HANDLE)
    			throw new Win32Exception();
    		try {
    			IO_STATUS_BLOCK iosb = new IO_STATUS_BLOCK();
    			FILE_CASE_SENSITIVE_INFORMATION caseSensitive = new FILE_CASE_SENSITIVE_INFORMATION();
    			NTSTATUS status = NtQueryInformationFile(hFile, ref iosb, ref caseSensitive,
    														Marshal.SizeOf<FILE_CASE_SENSITIVE_INFORMATION>(),
    														FILE_INFORMATION_CLASS.FileCaseSensitiveInformation);
    			switch (status) {
    			case NTSTATUS.SUCCESS:
    				return caseSensitive.Flags.HasFlag(CASE_SENSITIVITY_FLAGS.CaseSensitiveDirectory);
    
    			case NTSTATUS.NOT_IMPLEMENTED:
    			case NTSTATUS.NOT_SUPPORTED:
    			case NTSTATUS.INVALID_INFO_CLASS:
    			case NTSTATUS.INVALID_PARAMETER:
    				// Not supported, must be older version of windows.
    				// Directory case sensitivity is impossible.
    				return false;
    			default:
    				throw new Exception($"Unknown NTSTATUS: {status:X8}!");
    			}
    		}
    		finally {
    			CloseHandle(hFile);
    		}
    	}
    }
