    partial class NativeMethods {
        public const FileAccess FILE_WRITE_ATTRIBUTES = (FileAccess) 0x00000100;
    
    	// An override, specifically made for FileCaseSensitiveInformation, no IntPtr necessary.
    	[DllImport("ntdll.dll")]
    	[return: MarshalAs(UnmanagedType.U4)]
    	public static extern NTSTATUS NtSetInformationFile(
    		IntPtr FileHandle,
    		ref IO_STATUS_BLOCK IoStatusBlock,
    		ref FILE_CASE_SENSITIVE_INFORMATION FileInformation,
    		int Length,
    		FILE_INFORMATION_CLASS FileInformationClass);
    
    	// Require's elevated priviledges
    	public static void SetDirectoryCaseSensitive(string directory, bool enable) {
    		// FILE_WRITE_ATTRIBUTES access is the only requirement
    		IntPtr hFile = CreateFile(directory, FILE_WRITE_ATTRIBUTES, FileShare.ReadWrite,
    									IntPtr.Zero, FileMode.Open,
    									FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);
    		if (hFile == INVALID_HANDLE)
    			throw new Win32Exception();
    		try {
    			IO_STATUS_BLOCK iosb = new IO_STATUS_BLOCK();
    			FILE_CASE_SENSITIVE_INFORMATION caseSensitive = new FILE_CASE_SENSITIVE_INFORMATION();
    			if (enable)
    				caseSensitive.Flags |= CASE_SENSITIVITY_FLAGS.CaseSensitiveDirectory;
    			NTSTATUS status = NtSetInformationFile(hFile, ref iosb, ref caseSensitive,
    													Marshal.SizeOf<FILE_CASE_SENSITIVE_INFORMATION>(),
    													FILE_INFORMATION_CLASS.FileCaseSensitiveInformation);
    			switch (status) {
    			case NTSTATUS.SUCCESS:
    				return;
                case NTSTATUS.DIRECTORY_NOT_EMPTY:
				    throw new IOException($"Directory \"{directory}\" is not empty! " +
									      $"Cannot set case sensitivity!");
    
    			case NTSTATUS.NOT_IMPLEMENTED:
    			case NTSTATUS.NOT_SUPPORTED:
    			case NTSTATUS.INVALID_INFO_CLASS:
    			case NTSTATUS.INVALID_PARAMETER:
    				// Not supported, must be older version of windows.
    				// Directory case sensitivity is impossible.
    				throw new NotSupportedException("This version of Windows does not support directory case sensitivity!");
    			default:
    				throw new Exception($"Unknown NTSTATUS: {(uint)status:X8}!");
    			}
    		}
    		finally {
    			CloseHandle(hFile);
    		}
    	}
    }
