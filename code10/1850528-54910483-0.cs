     public class ProcessUtility
        {
            /// <summary>
            /// https://www.geoffchappell.com/studies/windows/km/ntoskrnl/api/ex/sysinfo/handle_table_entry.htm?ts=0,242
            /// </summary>
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            private struct SYSTEM_HANDLE_INFORMATION
            { // Information Class 16
                public ushort ProcessID;
                public ushort CreatorBackTrackIndex;
                public byte ObjectType;
                public byte HandleAttribute;
                public ushort Handle;
                public IntPtr Object_Pointer;
                public IntPtr AccessMask;
            }
            private enum OBJECT_INFORMATION_CLASS : int
            {
                ObjectBasicInformation = 0,
                ObjectNameInformation = 1,
                ObjectTypeInformation = 2,
                ObjectAllTypesInformation = 3,
                ObjectHandleInformation = 4
            }
            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            private struct OBJECT_NAME_INFORMATION
            { // Information Class 1
                public UNICODE_STRING Name;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct UNICODE_STRING
            {
                public ushort Length;
                public ushort MaximumLength;
                public IntPtr Buffer;
            }
            [Flags]
            private enum PROCESS_ACCESS_FLAGS : uint
            {
                All = 0x001F0FFF,
                Terminate = 0x00000001,
                CreateThread = 0x00000002,
                VMOperation = 0x00000008,
                VMRead = 0x00000010,
                VMWrite = 0x00000020,
                DupHandle = 0x00000040,
                SetInformation = 0x00000200,
                QueryInformation = 0x00000400,
                Synchronize = 0x00100000
            }
            private enum FileType : uint
            {
                FileTypeChar = 0x0002,
                FileTypeDisk = 0x0001,
                FileTypePipe = 0x0003,
                FileTypeRemote = 0x8000,
                FileTypeUnknown = 0x0000,
            }
            [DllImport("ntdll.dll")]
            private static extern uint NtQuerySystemInformation(int SystemInformationClass, IntPtr SystemInformation, int SystemInformationLength, ref int returnLength);
            [DllImport("kernel32.dll")]
            private static extern IntPtr OpenProcess(PROCESS_ACCESS_FLAGS dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle, uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetCurrentProcess();
            [DllImport("ntdll.dll")]
            private static extern int NtQueryObject(IntPtr ObjectHandle, int ObjectInformationClass, IntPtr ObjectInformation, int ObjectInformationLength, ref int returnLength);
            [DllImport("kernel32.dll")]
            private static extern bool CloseHandle(IntPtr hObject);
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);
            [DllImport("kernel32.dll")]
            private static extern bool GetHandleInformation(IntPtr hObject, out uint lpdwFlags);
            [DllImport("kernel32.dll")]
            private static extern FileType GetFileType(IntPtr hFile);
            private const int MAX_PATH = 260;
            private const uint STATUS_INFO_LENGTH_MISMATCH = 0xC0000004;
            private const int DUPLICATE_SAME_ACCESS = 0x2;
            private const uint FILE_SEQUENTIAL_ONLY = 0x00000004;
            private const int CNST_SYSTEM_HANDLE_INFORMATION = 0x10;
            private const int OBJECT_TYPE_FILE = 0x24;
            public static List<string> FindFilesByExtension(List<Process> target_processes, List<string> target_extensions)
            {
                List<string> aFilePaths = new List<string>();
                if (target_extensions == null || target_extensions.Count == 0)
                {
                    throw new Exception("Exceptions not defined");
                }
                foreach (Process process in target_processes)
                {
                    List<string> aProcessFiles = GetPrcessFiles(target_processes);
                    foreach (string file_path in aProcessFiles)
                    {
                        if (target_extensions.Contains(Path.GetExtension(file_path.ToLower()))
                            && !Path.GetFileName(file_path).StartsWith("~"))
                        {
                            aFilePaths.Add(file_path);
                        }
                    }
                }
                return aFilePaths;
            }
            public static List<string> GetPrcessFiles(List<Process> target_processes)
            {
                List<string> aFiles = new List<string>();
                foreach (Process process in target_processes)
                {
                    List<SYSTEM_HANDLE_INFORMATION> aHandles = GetFileHandles(process).ToList();
                    foreach (SYSTEM_HANDLE_INFORMATION handle_info in aHandles)
                    {
                        string file_path = GetFilePath(handle_info, process);
                        if (!string.IsNullOrEmpty(file_path))
                        {
                            aFiles.Add(file_path);
                        }
                    }
                }
                return aFiles;
            }
            private static IEnumerable<SYSTEM_HANDLE_INFORMATION> GetFileHandles(Process process)
            {
                List<SYSTEM_HANDLE_INFORMATION> aHandles = new List<SYSTEM_HANDLE_INFORMATION>();
                int handle_info_size = Marshal.SizeOf(new SYSTEM_HANDLE_INFORMATION()) * 20000;
                IntPtr ptrHandleData = IntPtr.Zero;
                try
                {
                    ptrHandleData = Marshal.AllocHGlobal(handle_info_size);
                    int nLength = 0;
                    while (NtQuerySystemInformation(CNST_SYSTEM_HANDLE_INFORMATION, ptrHandleData, handle_info_size, ref nLength) == STATUS_INFO_LENGTH_MISMATCH)
                    {
                        handle_info_size = nLength;
                        Marshal.FreeHGlobal(ptrHandleData);
                        ptrHandleData = Marshal.AllocHGlobal(nLength);
                    }
                    long handle_count = Marshal.ReadIntPtr(ptrHandleData).ToInt64();
                    IntPtr ptrHandleItem = ptrHandleData + Marshal.SizeOf(ptrHandleData);
                    for (long lIndex = 0; lIndex < handle_count; lIndex++)
                    {
                        SYSTEM_HANDLE_INFORMATION oSystemHandleInfo = Marshal.PtrToStructure<SYSTEM_HANDLE_INFORMATION>(ptrHandleItem);
                        ptrHandleItem += Marshal.SizeOf(new SYSTEM_HANDLE_INFORMATION());
                        if (oSystemHandleInfo.ProcessID != process.Id || oSystemHandleInfo.ObjectType != OBJECT_TYPE_FILE)
                        { continue; }
                        aHandles.Add(oSystemHandleInfo);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Marshal.FreeHGlobal(ptrHandleData);
                }
                return aHandles;
            }
            private static string GetFilePath(SYSTEM_HANDLE_INFORMATION systemHandleInformation, Process process)
            {
                IntPtr ipHandle = IntPtr.Zero;
                IntPtr openProcessHandle = IntPtr.Zero;
                IntPtr hObjectName = IntPtr.Zero;
                try
                {
                    PROCESS_ACCESS_FLAGS flags = PROCESS_ACCESS_FLAGS.DupHandle | PROCESS_ACCESS_FLAGS.VMRead;
                    openProcessHandle = OpenProcess(flags, false, process.Id);
                    if (!DuplicateHandle(openProcessHandle, new IntPtr(systemHandleInformation.Handle), GetCurrentProcess(), out ipHandle, 0, false, DUPLICATE_SAME_ACCESS))
                    {
                        return null;
                    }
                    if (GetFileType(ipHandle) != FileType.FileTypeDisk)
                    { return null; }
                    int nLength = 0;
                    hObjectName = Marshal.AllocHGlobal(256 * 1024);
                    while ((uint)(NtQueryObject(ipHandle, (int)OBJECT_INFORMATION_CLASS.ObjectNameInformation, hObjectName, nLength, ref nLength)) == STATUS_INFO_LENGTH_MISMATCH)
                    {
                        Marshal.FreeHGlobal(hObjectName);
                        if (nLength == 0)
                        {
                            Console.WriteLine("Length returned at zero!");
                            return null;
                        }
                        hObjectName = Marshal.AllocHGlobal(nLength);
                    }
                    OBJECT_NAME_INFORMATION objObjectName = Marshal.PtrToStructure<OBJECT_NAME_INFORMATION>(hObjectName);
                    if (objObjectName.Name.Buffer != IntPtr.Zero)
                    {
                        string strObjectName = Marshal.PtrToStringUni(objObjectName.Name.Buffer);
                        return GetRegularFileNameFromDevice(strObjectName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Marshal.FreeHGlobal(hObjectName);
                    CloseHandle(ipHandle);
                    CloseHandle(openProcessHandle);
                }
                return null;
            }
            private static string GetRegularFileNameFromDevice(string strRawName)
            {
                string strFileName = strRawName;
                foreach (string strDrivePath in Environment.GetLogicalDrives())
                {
                    var sbTargetPath = new StringBuilder(MAX_PATH);
                    if (QueryDosDevice(strDrivePath.Substring(0, 2), sbTargetPath, MAX_PATH) == 0)
                    {
                        return strRawName;
                    }
                    string strTargetPath = sbTargetPath.ToString();
                    if (strFileName.StartsWith(strTargetPath))
                    {
                        strFileName = strFileName.Replace(strTargetPath, strDrivePath.Substring(0, 2));
                        break;
                    }
                }
                return strFileName;
            }
        }
