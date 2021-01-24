    partial class NativeMethods {
        // Use the same directory so it does not need to be recreated when restarting the program
    	private static readonly string TempDirectory =
    		Path.Combine(Path.GetTempPath(), "88DEB13C-E516-46C3-97CA-46A8D0DDD8B2");
    
    	private static bool? isSupported;
    	public static bool IsDirectoryCaseSensitivitySupported() {
    		if (isSupported.HasValue)
    			return isSupported.Value;
    			
    		// Make sure the directory exists
    		if (!Directory.Exists(TempDirectory))
    			Directory.CreateDirectory(TempDirectory);
    				
    		IntPtr hFile = CreateFile(TempDirectory, 0, FileShare.ReadWrite,
    								IntPtr.Zero, FileMode.Open,
    								FILE_FLAG_BACKUP_SEMANTICS, IntPtr.Zero);
    		if (hFile == INVALID_HANDLE)
    			throw new Exception("Failed to open file while checking case sensitivity support!");
    		try {
    			IO_STATUS_BLOCK iosb = new IO_STATUS_BLOCK();
    			FILE_CASE_SENSITIVE_INFORMATION caseSensitive = new FILE_CASE_SENSITIVE_INFORMATION();
    			// Strangely enough, this doesn't fail on files
    			NTSTATUS result = NtQueryInformationFile(hFile, ref iosb, ref caseSensitive,
    														Marshal.SizeOf<FILE_CASE_SENSITIVE_INFORMATION>(),
    														FILE_INFORMATION_CLASS.FileCaseSensitiveInformation);
    			switch (result) {
    			case NTSTATUS.SUCCESS:
    				return (isSupported = true).Value;
    			case NTSTATUS.NOT_IMPLEMENTED:
    			case NTSTATUS.INVALID_INFO_CLASS:
    			case NTSTATUS.INVALID_PARAMETER:
    			case NTSTATUS.NOT_SUPPORTED:
    				// Not supported, must be older version of windows.
    				// Directory case sensitivity is impossible.
    				return (isSupported = false).Value;
    			default:
    				throw new Exception($"Unknown NTSTATUS {result:X8} while checking case sensitivity support!");
    			}
    		}
    		finally {
    			CloseHandle(hFile);
    			try {
    				// CHOOSE: If you delete the folder, future calls to this will not be any faster
    				// Directory.Delete(TempDirectory);
    			}
    			catch { }
    		}
    	}
    }
